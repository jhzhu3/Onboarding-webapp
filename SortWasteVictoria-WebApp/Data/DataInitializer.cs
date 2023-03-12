using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SortWasteVictoria_WebApp.Data;
using SortWasteVictoria_WebApp.JsonModels;
using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.Data
{
    public class DataInitializer
    {
        public static void SeedBinData(SortWasteVictoria_WebAppContext context)
        {
            if (context.Bin.Any())
            {
                return; //database has been seeded
            }
            List<JsonModels.JsonBins> jsonBins = new List<JsonModels.JsonBins>();
            using (StreamReader r = new StreamReader("wwwroot/files/bin.json"))
            { 
                string json = r.ReadToEnd();
                jsonBins = JsonConvert.DeserializeObject<List<JsonModels.JsonBins>>(json);
            }

            foreach (JsonModels.JsonBins jsonBin in jsonBins)
            {
                context.Bin.AddRange(
                    new Bin()
                    { 
                        //BinId = jsonBin.BinId,
                        BinColour = jsonBin.BinColour,
                        BinInfo = jsonBin.BinInfo
                    }
                    );

            }
            context.SaveChanges();

        }
        public static void SeedGarbageData(SortWasteVictoria_WebAppContext context)
        {
            if (context.Garbage.Any())
            {
                return; //database has been seeded
            }
            List<JsonModels.JsonGarbages> jsonGarbages = new List<JsonModels.JsonGarbages>();
            using (StreamReader r = new StreamReader("wwwroot/files/garbage.json"))
            {
                string json = r.ReadToEnd();
                jsonGarbages = JsonConvert.DeserializeObject<List<JsonModels.JsonGarbages>>(json);
            }

            foreach (JsonModels.JsonGarbages jsonGarbage in jsonGarbages)
            {
                context.Garbage.AddRange(
                    new Garbage()
                    {
                        GarbageName = jsonGarbage.GarbageName,
                        BinId = jsonGarbage.BinId
                    }
                    );
            }
            context.SaveChanges();
        }

        public static void deleteBinItem(SortWasteVictoria_WebAppContext context)
        {
            context.Bin.Remove(context.Bin.Find(6));
            context.Bin.Remove(context.Bin.Find(7));
            context.Bin.Remove(context.Bin.Find(8));
            context.Bin.Remove(context.Bin.Find(9));
            context.Bin.Remove(context.Bin.Find(10));
            context.SaveChanges();
        }
        /*public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new SortWasteVictoria_WebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<SortWasteVictoria_WebAppContext>>()))
            {
                //Look for bin + garbage data
                if (!context.Bin.Any() && !context.Garbage.Any())
                {
                    return;
                }
                //get the json file from the path
                var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
                var binPath = Path.Combine(env.WebRootPath, "files", "bin.json");
                var garbagePath = Path.Combine(env.WebRootPath, "files", "garbage.json");
                //read the json content and then deserialize it to object
                var binJsonString = File.ReadAllText(binPath);
                var garbageJsonString = File.ReadAllText(garbagePath);

                List<Bin> binList = JsonConvert.DeserializeObject<List<Bin>>(binJsonString);
                List<Garbage> garbageList = JsonConvert.DeserializeObject<List<Garbage>>(garbageJsonString);

                foreach (var bin in binList) 
                { 
                    context.Bin.Add(bin);
                    context.SaveChanges();
                }

                foreach (var garbage in garbageList)
                { 
                    context.Garbage.Add(garbage);
                }
                

            }
        }*/
        /*public static async Task SeedData(SortWasteVictoria_WebAppContext context)
        {
            if (!context.Bin.Any())
            {
                if (!File.Exists("SortWasteVictoria-WebApp/Data/bin.json"))
                {
                    throw new Exception("Seed data file not found");
                }
                else 
                {
                    string binsJson = File.ReadAllText("SortWasteVictoria-WebApp/Data/bin.json");

                    List<Bin> binList = JsonConvert.DeserializeObject<List<Bin>>(binsJson);

                    await context.Bin.AddRangeAsync(binList);
                    await context.SaveChangesAsync();
                }
                
            }

            if (!context.Garbage.Any())
            {
                if (!File.Exists("SortWasteVictoria-WebApp/Data/garbage.json"))
                {
                    throw new Exception("Seed data file not found");
                }
                else
                {
                    string garbagesJson = File.ReadAllText("SortWasteVictoria-WebApp/Data/garbage.json");

                    List<Garbage> garbageList = JsonConvert.DeserializeObject<List<Garbage>>(garbagesJson);

                    await context.Garbage.AddRangeAsync(garbageList);
                    await context.SaveChangesAsync();
                }

            }
        }*/
    }
}
