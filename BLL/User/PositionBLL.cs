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
                newPosition.Description.Trim();
                if (PositionDAL.checkPositionExist(newPosition.Positionname) == true)
                {
                    result.isError = true;
                    result.message = "Exception at Position BLL";
                    result.messageDetail = "Position with name : " + newPosition.Positionname + " is exist";
                    result.dataObject = null;
                }
                else
                {
                    positionObj = PositionDAL.insertNewPosition(newPosition);
                    if (positionObj == null)
                    {
                        result.isError = true;
                        result.message = "Exception at Position BLL";
                        result.messageDetail = String.Empty;
                        result.dataObject = null;
                    }
                    else
                    {
                        result.isError = false;
                        result.message = "Insert new Position success";
                        result.messageDetail = String.Empty;
                        result.dataObject = positionObj;
                    }
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

        public static ResultObject updatePosition(MdPosition updatePosition)
        {
            ResultObject result = new ResultObject();
            try
            {

                MdPosition checkPosition = PositionDAL.findPosition(updatePosition.Positionid);
                if(checkPosition == null)
                {
                    result.isError = true;
                    result.message = "Cannot find position with Id = " + updatePosition.Positionid.ToString();
                    result.messageDetail = String.Empty;
                    result.dataObject = null;
                }

                else
                {
                    checkPosition = PositionDAL.updatePosition(updatePosition);
                    if(checkPosition == null)
                    {
                        result.isError = true;
                        result.message = "Execption at Update position BLL";
                        result.messageDetail = String.Empty;
                        result.dataObject = null;
                    }
                    else
                    {
                        result.isError = false;
                        result.message = "Update Position success";
                        result.messageDetail = String.Empty;
                        result.dataObject = checkPosition;
                    }
                }
            }
            catch (Exception ex)
            {
                result.isError = true;
                result.message = "Execption at Update position BLL";
                result.messageDetail = ex.ToString();
                result.dataObject = null;
            }


            return result;
        }


        public static ResultObject deletePosition(decimal deletePositionId)
        {
            ResultObject result = new ResultObject();
            try
            {

                MdPosition checkPosition = PositionDAL.findPosition(deletePositionId);
                if (checkPosition == null)
                {
                    result.isError = true;
                    result.message = "Cannot find position with Id = " + deletePositionId.ToString();
                    result.messageDetail = String.Empty;
                    result.dataObject = null;
                }

                else
                {
                    checkPosition = PositionDAL.deletePosition(checkPosition);
                    if (checkPosition == null)
                    {
                        result.isError = true;
                        result.message = "Execption at Delete position BLL";
                        result.messageDetail = String.Empty;
                        result.dataObject = null;
                    }
                    else
                    {
                        result.isError = false;
                        result.message = "Delete Position success";
                        result.messageDetail = String.Empty;
                        result.dataObject = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.isError = true;
                result.message = "Execption at Delete position BLL";
                result.messageDetail = ex.ToString();
                result.dataObject = null;
            }


            return result;
        }


    }
}

