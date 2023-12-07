namespace VRMS_3layers.Models.ResultObj
{
    public class ResultObject
    {
        public bool isError { get; set; }
        public string message { get; set; }
        public string messageDetail { get; set; }
        public Object dataObject { get; set; }
        public ResultObject(bool isError, string message, string messageDetail, Object dataObject)
        {
            this.isError = isError;
            this.message = message;
            this.messageDetail = messageDetail;
            this.dataObject = dataObject;
        }

        public ResultObject()
        {
        }



    }
}
