using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.User
{
    public class PositionDAL
    {
        public static List<MdPosition> getListPosition()
        {
            List<MdPosition> listPositions = new List<MdPosition>();

            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    listPositions = _userDbContext.MdPositions.Where<MdPosition>(p => p.Isdeleted == 0).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return listPositions;
        }

        public static decimal getLastId()
        {
            decimal result = 0;
            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    result = _userDbContext.MdPositions.Max<MdPosition>(p => p.Positionid);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString);
                }
            }

                return result;
        }


        public static bool checkPositionExist(String positionName)
        {
            bool result = false;

            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    String checkPositionName = _userDbContext.MdPositions.FirstOrDefault<MdPosition>(p => p.Positionname.Trim() == positionName).Positionname;
                    if(checkPositionName == null || checkPositionName == " ")
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    Console.WriteLine(ex.ToString());
                }
            }


            return result;
        }


        public static MdPosition insertNewPosition(MdPosition insertPosition)
        {
            MdPosition result = new MdPosition();
            try
            {
                using (var _userDbContext = new ModelsDbContextcs())
                {
                    insertPosition.Positionid = getLastId() + 1;
                    insertPosition.Isdeleted = 0;
                    insertPosition.Deleteddate = null;
                    insertPosition.Createddate = DateOnly.FromDateTime(DateTime.Now);
                    _userDbContext.Add(insertPosition);
                    _userDbContext.SaveChanges();
                    result = insertPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = null;
            }
            return result;
        }



        public static MdPosition findPosition(decimal positionId)
        {
            MdPosition result = new MdPosition();

            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    result = _userDbContext.MdPositions.FirstOrDefault<MdPosition>(p => p.Positionid == positionId);
                }
                catch (Exception ex)
                {
                    result = null;
                    Console.WriteLine(ex.ToString);
                }
            }

                return result;
        }


        public static MdPosition updatePosition(MdPosition updatePosition)
        {
            MdPosition result = new MdPosition();
            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    result = _userDbContext.MdPositions.FirstOrDefault<MdPosition>(p => p.Positionid == updatePosition.Positionid);
                    result.Positionname = updatePosition.Positionname;
                    result.Description = updatePosition.Description;
                    _userDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    result = null;
                    Console.WriteLine(ex.ToString);
                }
            }
                return result;
        }

        public static MdPosition deletePosition(MdPosition updatePosition)
        {
            MdPosition result = new MdPosition();
            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    result = _userDbContext.MdPositions.FirstOrDefault<MdPosition>(p => p.Positionid == updatePosition.Positionid);
                    result.Isdeleted = 1;
                    result.Deleteddate = DateOnly.FromDateTime(DateTime.Now);
                    _userDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    result = null;
                    Console.WriteLine(ex.ToString);
                }
            }
            return result;
        }


    }
}
