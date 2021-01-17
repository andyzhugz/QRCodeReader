using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;



namespace QRCodeReader.Controllers
{
    /// <summary>
    /// Text class to deserialize response
    /// </summary>
    public class Text
    {
        public string type { get; set; }
        public List<Symbol> symbol { get; set; }
    }

    /// <summary>
    /// Symbol class to deserialize response
    /// </summary>
    public class Symbol
    {
        public string seq { get; set; }
        public string data { get; set; }
        public string error { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class QRCodeReaderController : ControllerBase
    {
        private readonly ILogger<QRCodeReaderController> _logger;
        public QRCodeReaderController(ILogger<QRCodeReaderController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Helper function to read the bytes array of the image
        /// </summary>
        /// <param name="path">filePath of the image</param>
        /// <returns>bytes array of the image</returns>
        private byte[] getImage(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            byte[] data = new byte[fileInfo.Length];

            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            return data;
        }

        /// <summary>
        /// Helper function to read the text from QRcode
        /// </summary>
        /// <param name="path">filePath of the QRcode image</param>
        /// <returns>response string</returns>
        private async Task<string> readCode(string path)
        {
            // read data using given path
            byte[] data = getImage(path);
            string url = "http://api.qrserver.com/v1/read-qr-code/";
            HttpContent bytesContent = new ByteArrayContent(data);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(bytesContent, "file", "file");
                var response = await client.PostAsync(url, formData);
                if (!response.IsSuccessStatusCode)
                {
                    return "error";
                }
                string res = await response.Content.ReadAsStringAsync();
                return res;
            }
        }


        [HttpGet("main")]
        public ActionResult<IEnumerable<string>> main()
        {
            return new[]
            {
                "This is the main page"
            };
        }


        [HttpGet("upload/{path}")]
        public async Task<String> getText(string path)
        {
            try
            {
                string text = await readCode(path);
                // deserialize response json string and extract what we need
                var result = JsonConvert.DeserializeObject<List<Text>>(text);
                return result[0].symbol[0].data;
            }
            catch
            {
                return "error";
            }
        }
    }
}
