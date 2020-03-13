namespace ImagePro.Models
{
    public class EmptyInputError
    {
        public int ErrorCode { get => 101; } // map to 400

        public string Message { get => "Unable to perform operation due to empty input"; }
    }
    public class InvalidOperationError
    {
        public int ErrorCode { get => 100; } // map to 405
        public string Message { get => "Invalid operation, Supported operations are: FLIP, ROTATE, RESIZE, GRAYSCALE, THUMBNAIL. Please check inputs"; }
    }

    public class InvalidInputParameterError
    {
        public int ErrorCode { get => 103; } // map to 409

        public string Message { get => "Invalid input parameters, Please check inputs"; }
    }
}