# Bubber dinner app from youtube


## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register request
```json
{
  "fistName": "Antonio",
  "lastName": "Medina",
  "email": "antonio@medina.com",
  "password": "Ant123!"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login request
```json
{
  "email": "antonio@medina.com",
  "password": "Ant123!"
}
```


