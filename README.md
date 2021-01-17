# QRCodeReader

# Introduction
This API project is designed to read QR code.
It has an endpoint which takes a local file system file path, reads the file and sends the file to the API `http://api.qrserver.com/v1/read-qr-code/`.
The return of the endpoint would be text data encoded in the QR code.

This API should only be built and run on the local machine. If you are going to deploy it, please directly use `http://api.qrserver.com/v1/read-qr-code/` to upload file and get the text data.


# Routes
| URL | Method | Description |
| --- | --- | --- |
| ‘/api/qrcodereader/main’ | GET | main page |
| ‘/api/qrcodereader/upload/{path}’ | GET | get the text from QR CODE |

e.g. when use curl to test,
`curl -X GET "https://localhost:5001/api/qrcodereader/upload/{path}`

Default port is 5001.

