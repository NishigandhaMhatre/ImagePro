### Example

```
POST /multipleOperation
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}
```


========================================
```
POST /flip
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}
```


========================================
```
POST /rotate
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}
```


========================================
```
POST /resize
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}
```


========================================
```
POST /greyScale
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}
```
========================================
```
POST /thumbnail
```

```
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}


405 Not Allowed

{
  "message": "InvalidOperationError",
}
```
