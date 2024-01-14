using VRMS_3Layers.Models.User;

namespace VRMS_3layers.DAL.User
{
    public class PositionDAL
    {
        public static List<MdPosition> getListPosition()
        {
            List<MdPosition> listPositions = new List<MdPosition>();

            using (var _userDbContext = new UserDbContextcs())
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

        public static MdPosition insertNewPosition(MdPosition insertPosition)
        {
            MdPosition result = new MdPosition();
            try
            {
                using (var _userDbContext = new UserDbContextcs())
                {
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

    }
}
