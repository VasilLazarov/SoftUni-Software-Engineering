namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            #region ex2 - my test alone
            //            string result = ExportAlbumsInfo(context, 9);

            //            var expected = @"-AlbumName: Devil's advocate
            //-ReleaseDate: 07/21/2018
            //-ProducerName: Evgeni Dimitrov
            //-Songs:
            //---#1
            //---SongName: Numb
            //---Price: 13.99
            //---Writer: Kara-lynn Sharpous
            //---#2
            //---SongName: Ibuprofen
            //---Price: 26.50
            //---Writer: Stanford Daykin
            //-AlbumPrice: 40.49
            //-AlbumName: Flower shower
            //-ReleaseDate: 07/17/2018
            //-ProducerName: Evgeni Dimitrov
            //-Songs:
            //---#1
            //---SongName: It is my life
            //---Price: 13.00
            //---Writer: Stanford Daykin
            //---#2
            //---SongName: Cough Relief
            //---Price: 25.04
            //---Writer: Jessie Townby
            //-AlbumPrice: 38.04
            //-AlbumName: Two to tango
            //-ReleaseDate: 04/03/2018
            //-ProducerName: Evgeni Dimitrov
            //-Songs:
            //---#1
            //---SongName: Wide Awake
            //---Price: 8.99
            //---Writer: Marlee Olivet
            //---#2
            //---SongName: Levothyroxine Sodium
            //---Price: 16.42
            //---Writer: Carol Mitchell
            //-AlbumPrice: 25.41
            //-AlbumName: Dark matters
            //-ReleaseDate: 07/22/2018
            //-ProducerName: Evgeni Dimitrov
            //-Songs:
            //---#1
            //---SongName: In the end
            //---Price: 11.99
            //---Writer: Verine Eschalotte
            //-AlbumPrice: 11.99";
            //            //Console.WriteLine(result.Substring(385));
            //            Console.WriteLine($"My string length: {result.Length}");
            //            Console.WriteLine($"String from judge length: {expected.Length}");
            //            Console.WriteLine(result.Equals(expected));
            //            Console.WriteLine(result);
            #endregion


            #region ex2 - with Kriskata

            string result = ExportAlbumsInfo(context, 9);

            Console.WriteLine(result);

            #endregion
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            #region my test alone
            StringBuilder resultMy = new();
            var albumsInfoMy = context.Albums
                .Include(a => a.Producer)// not needed
                .Include(a => a.Songs)//not needed
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToList(),
                    TotalAlbumPrice = a.Price,
                })
                .ToList()
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            foreach (var album in albumsInfoMy)
            {
                resultMy.AppendLine($"-AlbumName: {album.AlbumName}");
                resultMy.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                resultMy.AppendLine($"-ProducerName: {album.ProducerName}");
                resultMy.AppendLine($"-Songs:");
                for (int i = 0; i < album.Songs.Count; i++)
                {
                    resultMy.AppendLine($"---#{i + 1}");
                    resultMy.AppendLine($"---SongName: {album.Songs[i].SongName}");
                    resultMy.AppendLine($"---Price: {album.Songs[i].SongPrice:f2}");
                    resultMy.AppendLine($"---Writer: {album.Songs[i].SongWriterName}");
                }
                resultMy.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }
            return resultMy.ToString().TrimEnd();
            #endregion

            #region ex2 - with Kriskata

            //StringBuilder result = new();

            //var albumsInfo = context.Albums
            //    .Where(a => a.ProducerId == producerId)
            //    .ToArray()
            //    .OrderByDescending(a => a.Price)
            //    .Select(a => new
            //    {
            //        AlbumName = a.Name,
            //        ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
            //        ProducerName = a.Producer.Name,
            //        Songs = a.Songs
            //            .Select(s => new
            //            {
            //                SongName = s.Name,
            //                SongPrice = s.Price.ToString("f2"),
            //                WriterName = s.Writer.Name
            //            })
            //            .OrderByDescending(s => s.SongName)
            //            .ThenBy(s => s.WriterName)
            //            .ToArray(),
            //        AlbumPrice = a.Price.ToString("f2")
            //    })
            //    .ToArray();

            //foreach (var a in albumsInfo)
            //{
            //    result.AppendLine($"-AlbumName: {a.AlbumName}");
            //    result.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
            //    result.AppendLine($"-ProducerName: {a.ProducerName}");
            //    result.AppendLine($"-Songs:");

            //    int songNumber = 1;
            //    foreach (var s in a.Songs)
            //    {
            //        result.AppendLine($"---#{songNumber}");
            //        result.AppendLine($"---SongName: {s.SongName}");
            //        result.AppendLine($"---Price: {s.SongPrice}");
            //        result.AppendLine($"---Writer: {s.WriterName}");
            //        songNumber++;
            //    }
            //    result.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            //}
            //string resultMyString = resultMy.ToString().TrimEnd();
            //string resultString = result.ToString().TrimEnd();
            //Console.WriteLine($"Mine: {resultMy.Length} - Kriskata: {result.Length}");
            //Console.WriteLine(resultMy.Equals(result));
            //Console.WriteLine($"Mine: {resultMyString.Length} - Kriskata: {resultString.Length}");
            //Console.WriteLine(resultMyString.Equals(resultString));
            //return result.ToString().TrimEnd();
            #endregion
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
