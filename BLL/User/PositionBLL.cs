using System;
using VRMS_3layers.DAL.User;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.Models.User;

namespace VRMS_3Layers.BLL.User
{
	public class PositionBLL
	{
		public static ResultObject getListPosition()
		{
			ResultObject result = new ResultObject();
			try
			{
                List<MdPosition> listPositions = PositionDAL.getListPosition();
				if(listPositions.Count <= 0 || listPositions == null)
				{
                    result.isError = false;
                    result.message = "List Department is empty ";
                    result.messageDetail = string.Empty;
                    result.dataObject = null;
                }
				else
				{
                    for (int i = 0; i <= listPositions.Count - 2; i++)
                    {
                        for (int j = 0; j <= listPositions.Count - 2; j++)
                        {
                            if (listPositions[j].Positionid > listPositions[j + 1].Positionid)
                            {
                                MdPosition temp = listPositions[j + 1];
                                listPositions[j + 1] = listPositions[j];
                                listPositions[j] = temp;
                            }
                        }
                    }
                    result.isError = false;
                    result.message = "Get List position success";
                    result.messageDetail = string.Empty;
                    result.dataObject = listPositions;
                }
            }
			catch (Exception ex)
			{
                result.isError = true;
                result.message = "Exception at Position BLL";
                result.messageDetail = ex.ToString();
                result.dataObject = null;
            }
			return result;
		}


        public static ResultObject insertNewPosition(MdPosition newPosition)
        {
            ResultObject result = new ResultObject();
            MdPosition positionObj = null;
            try
            {
                newPosition.Positionname.Trim();
                positionObj = PositionDAL.insertNewPosition(newPosition);
                if(positionObj == null)
                {
                    result.isError = true;
                    result.message = "Exception at Position BLL";
                    result.messageDetail = String.Empty;
                    result.dataObject = null;
                }
            }
            catch (Exception ex)
            {
                result.isError = true;
                result.message = "Exception at Position BLL";
                result.messageDetail = ex.ToString();
                result.dataObject = null;
            }

            return result;
        }

	}
}

