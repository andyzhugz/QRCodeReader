# QRCodeReader

# Routes
| URL | Method | Description |
| --- | --- | --- |
| ‘/api/qrcodereader/main’ | GET | main page |
| ‘/api/qrcodereader/upload/{path}’ | GET | get the text from QR CODE |

e.g.
`curl -X GET "https://localhost:5001/api/qrcodereader/upload/C:\Users\guangzhe\Desktop\qrcode.png"`
