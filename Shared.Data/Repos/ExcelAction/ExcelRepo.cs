using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
//using OfficeOpenXml;

namespace Agro.Shared.Data.Repos.ExcelAction
{
    public class KeyModel
    {
        public string type { get; set; }
        public List<Vid> Vids { get; set; }
        public class Vid
        {
            public string vid { get; set; }
            public List<Product> Products { get; set; }
            public class Product
            {
                public string product { get; set; }
                public List<Model> Models { get; set; }
                public class Model
                {
                    public Guid? Country { get; set; }
                    public Guid? Provider { get; set; }
                    public string model { get; set; }
                }
            }
        }

    }

    public class rast
    {
        public string cena { get; set; }
        public string ga { get; set; }
    }
    public class ExcelRepo : IExcelRepo
    {
        public DataContext _db;

        public ExcelRepo(DataContext db)
        {
            _db = db;
        }
        public void MigrateDB()
        {

            //_db.DicRegions.AddRange(new DicRegion()
            //{
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    IsDeleted = false,
            //    NameRu = "Акмолинская область",
            //    Code = "akmola",
            //    NameKz = "Акмолинская область"
            //},
            //    new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Актюбинская область",
            //        Code = "aktobe",
            //        NameKz = "Актюбинская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Алматинская область",
            //        Code = "almaty",
            //        NameKz = "Алматинская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Атырауская область",
            //        Code = "atyrau",
            //        NameKz = "Атырауская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Восточно-Казахстанская область",
            //        Code = "vko",
            //        NameKz = "Восточно-Казахстанская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Жамбылская область",
            //        Code = "zhambyl",
            //        NameKz = "Жамбылская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Западно-Казахстанская область",
            //        Code = "zko",
            //        NameKz = "Западно-Казахстанская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Карагандинская область",
            //        Code = "karagandy",
            //        NameKz = "Карагандинская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Костанайская область",
            //        Code = "kostanai",
            //        NameKz = "Костанайская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Кызылординская область",
            //        Code = "kyzylorda",
            //        NameKz = "Кызылординская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Акмолинская область",
            //        Code = "akmola",
            //        NameKz = "Акмолинская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Мангистауская область",
            //        Code = "mangystau",
            //        NameKz = "Мангистауская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Павлодарская область",
            //        Code = "pavlodar",
            //        NameKz = "Павлодарская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Северо-Казахстанская область",
            //        Code = "sko",
            //        NameKz = "Северо-Казахстанская область"
            //    }, new DicRegion()
            //    {
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        IsDeleted = false,
            //        NameRu = "Туркестанская область",
            //        Code = "turk",
            //        NameKz = "Туркестанская область"
            //    });
            //_db.SaveChanges();
            //var model = new Dictionary<string, rast>();
            //read the Excel file as byte array
            //byte[] bin = File.ReadAllBytes(@"C:\Works\KAF\back\Agro.Shared.Data\express.xlsx");
            //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            //create a new Excel package in a memorystream
            //using (MemoryStream stream = new MemoryStream(bin))
            //using (ExcelPackage excelPackage = new ExcelPackage(stream))
            //{
            //    loop all worksheets
            //    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            //    {
            //    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[7];
            //    for (int i = 3; i <= worksheet.Dimension.End.Column; i++)
            //    {
            //        if (worksheet.Cells[5, i].Value == null || worksheet.Cells[5, i].Value.ToString() == "")
            //        {
            //            continue;
            //        }

            //        Debug.WriteLine(worksheet.Cells[5, i].Value.ToString().Replace("\n", "").TrimEnd());
            //        model.Add(worksheet.Cells[5, i].Value.ToString().Replace("\n", "").TrimEnd(),
            //            new rast()
            //            {
            //                cena = worksheet.Cells[6, i].Value == null ? "" : worksheet.Cells[6, i].Value.ToString().Replace("\n", "").TrimEnd()
            //            }
            //            );
            //    }


            //}



            //Debug.WriteLine("++++++++++++++");
            //var posev = new Dictionary<string, string>();
            //using (MemoryStream stream = new MemoryStream(bin))
            //using (ExcelPackage excelPackage = new ExcelPackage(stream))
            //{
            //    loop all worksheets
            //    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            //    {
            //    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[6];
            //    for (int i = 3; i <= worksheet.Dimension.End.Column; i++)
            //    {
            //        if (worksheet.Cells[13, i].Value == null || worksheet.Cells[13, i].Value.ToString() == ""
            //        )
            //        {
            //            continue;
            //        }

            //        Debug.WriteLine(worksheet.Cells[13, i].Value.ToString().TrimEnd());
            //        posev.Add(worksheet.Cells[13, i].Value.ToString().Replace("\n", "").TrimEnd(), worksheet.Cells[14, i].Value.ToString().TrimEnd());


            //    }

            //    posev.Add(worksheet.Cells[8, 3].Value.ToString().Replace("\n", "").TrimEnd(), worksheet.Cells[10, 3].Value.ToString().Replace("\n", "").TrimEnd());
            //    posev.Add(worksheet.Cells[8, 5].Value.ToString().Replace("\n", "").TrimEnd(), worksheet.Cells[10, 5].Value.ToString().Replace("\n", "").TrimEnd());
            //    posev.Add(worksheet.Cells[8, 7].Value.ToString().Replace("\n", "").TrimEnd(), worksheet.Cells[10, 7].Value.ToString().Replace("\n", "").TrimEnd());




            //}

            //foreach (var itemPosev in posev)
            //{
            //    foreach (var itemModel in model)
            //    {

            //        if (itemPosev.Key.ToLower().Contains(itemModel.Key.ToLower()))
            //        {
            //            itemModel.Value.ga = itemPosev.Value;
            //        }
            //        else
            //        {
            //            var posevy = itemPosev.Key.Split(" ");
            //            var zatraty = itemModel.Key.Split(" ");
            //            if (posevy.Length > 1 && zatraty.Length > 1)
            //            {

            //                if (posevy[0].ToLower().Contains(zatraty[0].ToLower()) || posevy[0].ToLower().Contains(zatraty[1].ToLower())
            //                                                                       || posevy[1].ToLower().Contains(zatraty[0].ToLower())
            //                                                                       || posevy[1].ToLower().Contains(zatraty[1].ToLower())
            //                )
            //                {
            //                    itemModel.Value.ga = itemPosev.Value;
            //                }
            //            }

            //            if (posevy.Length > 1 && zatraty.Length < 2
            //            )
            //            {
            //                if (posevy[0].ToLower().Contains(zatraty[0].ToLower())
            //                   || posevy[1].ToLower().Contains(zatraty[0].ToLower()))
            //                {
            //                    itemModel.Value.ga = itemPosev.Value;
            //                }
            //            }
            //            if (posevy.Length < 2 && zatraty.Length > 1
            //                )
            //            {
            //                if (zatraty[0].ToLower().Contains(posevy[0].ToLower())
            //                   || zatraty[1].ToLower().Contains(posevy[0].ToLower()))
            //                {
            //                    itemModel.Value.ga = itemPosev.Value;
            //                }
            //            }

            //            if (posevy.Length < 2 && zatraty.Length < 2
            //            )
            //            {
            //                if (
            //                    posevy[0].ToLower().Contains(zatraty[0].ToLower()))
            //                {
            //                    itemModel.Value.ga = itemPosev.Value;
            //                }
            //            }
            //        }
            //    }
            //}
            //foreach (var item in model)
            //{
            //    _db.FloraCultures.Add(new Context.FloraCulture()
            //    {
            //        zatratyNa1Ga = item.Value.cena,
            //        normaVyseva = item.Value.ga,
            //        Name = item.Key,
            //        DicRegionId = new Guid("0CEC5E3E-1280-4064-EB8C-08D89E6A8D4B")
            //    });
            //    _db.SaveChanges();
            //}

            //#region techImport


            //List<KeyModel> res = new List<KeyModel>();
            //List<KeyModel.Vid> resVid = new List<KeyModel.Vid>();
            //List<KeyModel.Vid.Product> resProduct = new List<KeyModel.Vid.Product>();
            //List<KeyModel.Vid.Product.Model> resModel = new List<KeyModel.Vid.Product.Model>();

            ////create a list to hold all the values
            //List<string> countryList = new List<string>();
            //List<string> providerList = new List<string>();

            ////read the Excel file as byte array
            //byte[] bin = File.ReadAllBytes(@"C:\Works\KAF\back\Agro.Shared.Data\Реестр_предметов_лизинга___1__1_.xlsx");
            //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ////create a new Excel package in a memorystream
            //using (MemoryStream stream = new MemoryStream(bin))
            //using (ExcelPackage excelPackage = new ExcelPackage(stream))
            //{
            //    //loop all worksheets
            //    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            //    {

            //        for (int i = 4; i <= worksheet.Dimension.End.Row; i++)
            //        {
            //            if (worksheet.Cells[i, 4].Value == null || worksheet.Cells[i, 4].Value.ToString() == "")
            //            {
            //                continue;
            //            }

            //            if (worksheet.Cells[i, 4].Value.ToString() != null
            //                && !countryList.Contains(worksheet.Cells[i, 4].Value.ToString()))
            //            {
            //                countryList.Add(worksheet.Cells[i, 4].Value.ToString());
            //            }
            //        }
            //        for (int i = 4; i <= worksheet.Dimension.End.Row; i++)
            //        {
            //            if (worksheet.Cells[i, 7].Value == null || worksheet.Cells[i, 7].Value.ToString() == "")
            //            {
            //                continue;
            //            }

            //            if (worksheet.Cells[i, 7].Value.ToString() != null
            //                && !providerList.Contains(worksheet.Cells[i, 7].Value.ToString()))
            //            {
            //                providerList.Add(worksheet.Cells[i, 7].Value.ToString());
            //            }
            //        }

            //    }
            //}

            //int codeCountry = 1;
            //foreach (var item in countryList)
            //{
            //    _db.DicCountries.Add(new DicCountry()
            //    {
            //        Id = Guid.NewGuid(),
            //        NameRu = item,
            //        IsDeleted = false,
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        Code = codeCountry.ToString(),
            //        NameKz = item + "_KZ"
            //    });
            //    _db.SaveChanges();
            //    codeCountry++;
            //}
            //int codeProvider = 1;
            //foreach (var item in providerList)
            //{
            //    _db.DicProviders.Add(new DicProvider()
            //    {
            //        Id = Guid.NewGuid(),
            //        NameRu = item,
            //        IsDeleted = false,
            //        CreatedDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now,
            //        Code = codeProvider.ToString(),
            //        NameKz = item + "_KZ"
            //    });
            //    _db.SaveChanges();
            //    codeProvider++;
            //}
            //try
            //{
            //    //create a new Excel package in a memorystream
            //    using (MemoryStream stream = new MemoryStream(bin))
            //    using (ExcelPackage excelPackage = new ExcelPackage(stream))
            //    {
            //        //loop all worksheets
            //        foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            //        {
            //            int codes = 1;
            //            for (int i = 4; i <= worksheet.Dimension.End.Row; i++)
            //            {

            //                if (worksheet.Cells[i, 2].Value == null
            //                                                        || worksheet.Cells[i, 3].Value == null
            //                                                        || worksheet.Cells[i, 4].Value == null
            //                                                        || worksheet.Cells[i, 7].Value == null
            //                                                        || worksheet.Cells[i, 5].Value == null
            //                                                        || worksheet.Cells[i, 6].Value == null
            //                )
            //                {
            //                    continue;
            //                }

            //                if (worksheet.Cells[i, 2].Value.ToString().Trim() == "" ||
            //                    worksheet.Cells[i, 3].Value.ToString().Trim() == "" ||
            //                    worksheet.Cells[i, 4].Value.ToString().Trim() == "" ||
            //                    worksheet.Cells[i, 7].Value.ToString().Trim() == "" ||
            //                    worksheet.Cells[i, 6].Value.ToString().Trim() == "" ||
            //                    worksheet.Cells[i, 5].Value.ToString().Trim() == "")
            //                {
            //                    continue;

            //                }

            //                DicTechProduct result = null;
            //                var types = _db.DicTechTypes.FirstOrDefault(s =>
            //                    s.NameRu.ToLower().Replace("\n", "").Trim().Contains(worksheet.Cells[i, 2].Value.ToString().ToLower().Trim()));
            //                var subTypes = _db.DicTechTypes.FirstOrDefault(s =>
            //                    s.NameRu.ToLower().Replace("\n", "").Trim().Contains(worksheet.Cells[i, 3].Value.ToString().ToLower().Trim()));
            //                var productId = _db.DicTechProducts.Where(s =>
            //                    s.DicTechTypeId == types.Id || s.DicTechTypeId == subTypes.Id).ToList();

            //                foreach (var item in productId)
            //                {

            //                    var t = item.NameRu.Replace("\n", "").Trim();
            //                    if (item.NameRu.ToLower().Replace("\n", "").Trim().Contains(worksheet.Cells[i, 5].Value.ToString().ToLower().Replace("\n", "")))
            //                    {
            //                        result = item;
            //                    }
            //                }
            //                var provider = _db.DicProviders
            //                    .FirstOrDefault(s => s.NameRu.ToLower().Replace("\n", "").Trim().Contains(worksheet.Cells[i, 7].Value.ToString().ToLower().Trim()))?.Id;
            //                var Country = _db.DicCountries
            //                    .FirstOrDefault(s => s.NameRu.ToLower().Replace("\n", "").Trim().Contains(worksheet.Cells[i, 4].Value.ToString().ToLower().Trim()))?.Id;

            //                if (types != null && subTypes != null && provider.HasValue && Country.HasValue &&
            //                    result != null)
            //                {

            //                    _db.DicTechModels.Add(new DicTechModel()
            //                    {
            //                        CreatedDate = DateTime.Now,
            //                        ModifiedDate = DateTime.Now,
            //                        DicCountryId = Country.Value,
            //                        DicProviderId = provider.Value,
            //                        DicTechProductId = result.Id,
            //                        Code = codes.ToString(),
            //                        NameRu = worksheet.Cells[i, 6].Value.ToString()?.ToLower().Replace("\n", "").Trim()

            //                    });
            //                    _db.SaveChanges();
            //                    codes++;
            //                }

            //                #region MyRegion




            //                //var model = res.FirstOrDefault(s =>
            //                //    s.type.Contains(worksheet.Cells[i, 2].Value.ToString() ?? string.Empty));
            //                //if (!string.IsNullOrWhiteSpace(model?.type))
            //                //{
            //                //    var innerModel = model.Vids.FirstOrDefault(s =>
            //                //        s.vid.Contains(worksheet.Cells[i, 2].Value.ToString() ?? string.Empty));
            //                //    if (!string.IsNullOrWhiteSpace(innerModel?.vid))
            //                //    {
            //                //        var inInnerModel = innerModel.Products.FirstOrDefault(s =>
            //                //            s.product.Contains(worksheet.Cells[i, 2].Value.ToString() ?? string.Empty));
            //                //        if (!string.IsNullOrWhiteSpace(inInnerModel?.product))
            //                //        {
            //                //            inInnerModel.Models.Add(new KeyModel.Vid.Product.Model()
            //                //            {
            //                //                model = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                Provider = _db.DicProviders.FirstOrDefault(s => s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id,
            //                //                Country = _db.DicCountries.FirstOrDefault(s => s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id
            //                //            });
            //                //        }
            //                //        else
            //                //        {
            //                //            innerModel.Products.Add(new KeyModel.Vid.Product()
            //                //            {
            //                //                product = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                Models = new List<KeyModel.Vid.Product.Model>()
            //                //                {
            //                //                    new KeyModel.Vid.Product.Model()
            //                //                    {
            //                //                        model = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                        Provider = _db.DicProviders.FirstOrDefault(s=>s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id,
            //                //                        Country = _db.DicCountries.FirstOrDefault(s => s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id
            //                //                    }
            //                //                }
            //                //            });
            //                //        }
            //                //    }
            //                //    else
            //                //    {

            //                //        model.Vids.Add(new KeyModel.Vid()
            //                //        {
            //                //            vid = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //            Products = new List<KeyModel.Vid.Product>()
            //                //            {
            //                //                new KeyModel.Vid.Product()
            //                //                {
            //                //                    product = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                    Models = new List<KeyModel.Vid.Product.Model>()
            //                //                    {
            //                //                        new KeyModel.Vid.Product.Model()
            //                //                        {
            //                //                            model = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                            Provider = _db.DicProviders.FirstOrDefault(s=>s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id,
            //                //                            Country = _db.DicCountries.FirstOrDefault(s => s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id
            //                //                        }
            //                //                    }
            //                //                }
            //                //            }
            //                //        });
            //                //    }
            //                //}
            //                //else
            //                //{
            //                //    res.Add(new KeyModel()
            //                //    {
            //                //        type = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //        Vids = new List<KeyModel.Vid>()
            //                //        {
            //                //            new KeyModel.Vid()
            //                //            {
            //                //                vid = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                Products = new List<KeyModel.Vid.Product>()
            //                //                {
            //                //                    new KeyModel.Vid.Product()
            //                //                    {
            //                //                        product = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                        Models = new List<KeyModel.Vid.Product.Model>()
            //                //                        {
            //                //                            new KeyModel.Vid.Product.Model()
            //                //                            {
            //                //                                model = worksheet.Cells[i, 2].Value.ToString() ?? string.Empty,
            //                //                                Provider = _db.DicProviders.FirstOrDefault(s=>s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id,
            //                //                                Country = _db.DicCountries.FirstOrDefault(s => s.NameRu.Contains(worksheet.Cells[i, 2].Value.ToString()))?.Id
            //                //                            }
            //                //                        }
            //                //                    }
            //                //                }
            //                //            }
            //                //        }
            //                //    });

            //                //}

            //                #endregion
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{

            //}

            //#endregion
        }
    }
}
