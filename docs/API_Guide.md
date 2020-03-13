# Image Processing API Guide

An API platform that provides a solution for image processing such as:

* Flip Image
* Rotate Image
* Resize Image
* GrayScale Image
* Thumbnail of Image
* Perform multiple above operation in sequence in one api call

## Version
* Version: [1.0.0]
* Updated: [2020-03-12]

## Introduction


### Example

```
POST /multipleOperation
200 OK
{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}
```

========================================
```
POST /flip
200 OK
{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}
```

========================================
```
POST /rotate
200 OK
{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}
```

========================================
```
POST /resize
200 OK
{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}
```

========================================
```
POST /greyScale
200 OK
{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}
```

========================================
```
POST /thumbnail
200 OK

{
  "result": "<base64 string of image>",
  "message": "Success",
}

//Failed Scenarios
400 Bad Request
{
  "message": "EmptyInputError",
}

//Failed Scenarios
405 Not Allowed
{
  "message": "InvalidOperationError",
}

//Failed Scenarios
409 Conflict
{
  "message": "InvalidInputParameterError",
}

```
