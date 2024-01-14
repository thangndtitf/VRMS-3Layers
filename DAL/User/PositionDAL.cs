using VRMS_3Layers.Models.User;

namespace VRMS_3layers.DAL.User
{
    public class PositionDAL
    {
        public List<MdPosition> getListPosition()
        {
            List<MdPosition> listPositions = null;

            using (var _userDbContext = new UserDbContextcs())
            {
                try
                {
                    listPositions = _userDbContext.MdPositions.Where<MdPosition>(p => p.Isdeleted != 0).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return listPositions;
        }
    }
}
