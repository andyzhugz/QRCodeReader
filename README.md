# QRCodeReader

# Routes
| URL | Method | Description |
| --- | --- | --- |
| ‘/api/qrcodereader/main’ | GET | main page |
| ‘/api/qrcodereader/upload/{path}’ | GET | get the text from QR CODE |

e.g. when use curl to test,
`curl -X GET "https://localhost:5001/api/qrcodereader/upload/{path}`

Default port is 5001.
