using SQLite;

namespace PetGPS
{
    public static class Constants
     {
          private const string DBFileName = "PetGps.db3";

          public const SQLiteOpenFlags Flags =
               SQLiteOpenFlags.ReadWrite |
               SQLiteOpenFlags.Create |
               SQLiteOpenFlags.SharedCache;

          public static string DatabasePath
          {
               get
               {
                    return Path
                         .Combine(FileSystem.AppDataDirectory, DBFileName);
               }
          }
     }
}
