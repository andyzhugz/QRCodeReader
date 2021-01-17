# QRCodeReader

# Routes for Registration/Login
| URL | Method | Description | Body | Response |
| --- | --- | --- | --- | --- |
| ‘/Register’ | POST | Submits register information to the database, and redirects to the login page. | {username, nickname, password} | 201 or 409 |
| ‘/login’ | POST | Submits form data from login page, authenticates user, and redirects to feed. | {username(email), password} | 200 or 401 |
| ‘/logout’ | POST | Logs out of the user’s session and redirects to the login page. | N/A | 200 or 401 |
| ‘/checkAuthen’ | GET | Check if the request has been authenticated or not. | N/A | 200 or 401 |
| ‘/changePassword’ | POST | Change password and update in the database. | {username(email), newPassword} | 201, 400, or 422 |  
