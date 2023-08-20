namespace Web.Strategy.Models
{
    public class Settings
    {

        public static string claimDataBaseType = "databaseType";

        public EDataBaseType DataBaseType;
        public EDataBaseType GetDefaultDataBaseType => EDataBaseType.SqlServer;

    }
}
