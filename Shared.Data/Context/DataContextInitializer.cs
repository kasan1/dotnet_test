using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Enums.Identity;
using Microsoft.Extensions.Configuration;

namespace Agro.Shared.Data.Context
{
    public class DataContextInitializer
    {
        public static void SeedRolesAndPermissions(DataContext context)
        {
            if (!context.Roles.Any(x => x.Value == RoleType.Admin))
            {
                var role = new Role
                {
                    Value = RoleType.Admin,
                };

                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        private static string HashPwd(string pwd)
        {
            var alg = SHA512.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            return Convert.ToBase64String(alg.Hash);
        }
        public static void SeedPledgeDictionary(DataContext context)
        {
            #region DicAgriculturalMachineryPurpose

            DicAgriculturalMachineryPurpose[] agriculturalMachineryPurposes = { new DicAgriculturalMachineryPurpose { Code = "hinged", NameKk = "навесная", NameRu = "навесная" },
                                                                                new DicAgriculturalMachineryPurpose { Code = "trailed", NameKk = "прицепная", NameRu = "прицепная" },
                                                                                new DicAgriculturalMachineryPurpose { Code = "self-propelled", NameKk = "самоходная", NameRu = "самоходная" }};

            foreach (DicAgriculturalMachineryPurpose agriculturalMachineryPurpose in agriculturalMachineryPurposes)
            {
                if (!context.DicAgriculturalMachineryPurpose.Where(x => x.Code.Equals(agriculturalMachineryPurpose.Code)).Any())
                {
                    context.DicAgriculturalMachineryPurpose.Add(agriculturalMachineryPurpose);
                }
            }

            #endregion


            #region DicEquipmentPurpose

            DicEquipmentPurpose[] equipmentPurposes = { new DicEquipmentPurpose { Code = "trailed", NameKk = "прицепное", NameRu = "прицепное" },
                                                        new DicEquipmentPurpose { Code = "autonomous", NameKk = "автономное", NameRu = "автономное" }};

            foreach (DicEquipmentPurpose equipmentPurpose in equipmentPurposes)
            {
                if (!context.DicEquipmentPurpose.Where(x => x.Code.Equals(equipmentPurpose.Code)).Any())
                {
                    context.DicEquipmentPurpose.Add(equipmentPurpose);
                }
            }

            #endregion


            #region DicLandPurpose

            DicLandPurpose[] dicLandPurposes = { new DicLandPurpose { Code = "IJS-LPH", NameKk = "земельные участки с целевым назначением ИЖС, ЛПХ на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки с целевым назначением ИЖС, ЛПХ на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" },
                                                 new DicLandPurpose { Code = "arable-land", NameKk = "земельные участки сельскохозяйственного назначения (пашни) на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки сельскохозяйственного назначения (пашни) на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" },
                                                 new DicLandPurpose { Code = "pasture", NameKk = "земельные участки сельскохозяйственного назначения (пастбища, в том числе коренного улучшения, сенокосы) на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки сельскохозяйственного назначения (пастбища, в том числе коренного улучшения, сенокосы) на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" },
                                                 new DicLandPurpose { Code = "watering", NameKk = "земельные участки сельскохозяйственного назначения с инфраструктурой обводнения и ограждения пастбищ на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки сельскохозяйственного назначения с инфраструктурой обводнения и ограждения пастбищ на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" },
                                                 new DicLandPurpose { Code = "commercial", NameKk = "земельные участки, предназначенные для размещения и эксплуатации строений коммерческого назначения, принадлежащие на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки, предназначенные для размещения и эксплуатации строений коммерческого назначения, принадлежащие на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" },
                                                 new DicLandPurpose { Code = "production", NameKk = "земельные участки сельскохозяйственного производства, принадлежащие на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки", NameRu = "земельные участки сельскохозяйственного производства, принадлежащие на праве частной собственности либо право долгосрочного возмездного землепользования (аренды) на указанные земельные участки" }};

            foreach (DicLandPurpose dicLandPurpose in dicLandPurposes)
            {
                if (!context.DicLandPurpose.Where(x => x.Code.Equals(dicLandPurpose.Code)).Any())
                {
                    context.DicLandPurpose.Add(dicLandPurpose);
                }
            }

            #endregion


            #region DicCommercialОbjectName

            DicCommercialObjectName[] commercialОbjectNames = { new DicCommercialObjectName { Code = "built-in-room", NameKk = "встроенное помещение", NameRu = "встроенное помещение" },
                                                                new DicCommercialObjectName { Code = "detached-building", NameKk = "отдельностоящее здание", NameRu = "отдельностоящее здание" },
                                                                new DicCommercialObjectName { Code = "industrial-base", NameKk = "промышленная база", NameRu = "промышленная база" },
                                                                new DicCommercialObjectName { Code = "livestock-base", NameKk = "животноводческая база", NameRu = "животноводческая база" },
                                                                new DicCommercialObjectName { Code = "koshara", NameKk = "кошара", NameRu = "кошара" },
                                                                new DicCommercialObjectName { Code = "other", NameKk = "прочее", NameRu = "прочее" }};

            foreach (DicCommercialObjectName commercialОbjectName in commercialОbjectNames)
            {
                if (!context.DicCommercialОbjectName.Where(x => x.Code.Equals(commercialОbjectName.Code)).Any())
                {
                    context.DicCommercialОbjectName.Add(commercialОbjectName);
                }
            }

            #endregion


            #region DicCommercialОbjectPurpose

            DicCommercialObjectPurpose[] commercialОbjectPurposes = { new DicCommercialObjectPurpose { Code = "cafe", NameKk = "кафе", NameRu = "кафе" },
                                                                      new DicCommercialObjectPurpose { Code = "store", NameKk = "магазин", NameRu = "магазин" },
                                                                      new DicCommercialObjectPurpose { Code = "office", NameKk = "офис", NameRu = "офис" },
                                                                      new DicCommercialObjectPurpose { Code = "bath", NameKk = "баня", NameRu = "баня" },
                                                                      new DicCommercialObjectPurpose { Code = "restaurant", NameKk = "ресторан", NameRu = "ресторан" },
                                                                      new DicCommercialObjectPurpose { Code = "free-planning", NameKk = "свободной планировки", NameRu = "свободной планировки" },
                                                                      new DicCommercialObjectPurpose { Code = "beauty-saloon", NameKk = "салон красоты", NameRu = "салон красоты" },
                                                                      new DicCommercialObjectPurpose { Code = "other", NameKk = "прочее", NameRu = "прочее" }};

            foreach (DicCommercialObjectPurpose commercialОbjectPurpose in commercialОbjectPurposes)
            {
                if (!context.DicCommercialОbjectPurpose.Where(x => x.Code.Equals(commercialОbjectPurpose.Code)).Any())
                {
                    context.DicCommercialОbjectPurpose.Add(commercialОbjectPurpose);
                }
            }

            #endregion


            #region DicCommercialОbjectType

            DicCommercialObjectType[] commercialОbjectTypes = { new DicCommercialObjectType { Code = "shopping", NameKk = "торговые объекты", NameRu = "торговые объекты" },
                                                                new DicCommercialObjectType { Code = "production", NameKk = "производственные объекты", NameRu = "производственные объекты" },
                                                                new DicCommercialObjectType { Code = "administrative", NameKk = "административные, бытовые здания и помещения", NameRu = "административные, бытовые здания и помещения" }};

            foreach (DicCommercialObjectType commercialОbjectType in commercialОbjectTypes)
            {
                if (!context.DicCommercialОbjectType.Where(x => x.Code.Equals(commercialОbjectType.Code)).Any())
                {
                    context.DicCommercialОbjectType.Add(commercialОbjectType);
                }
            }

            #endregion


            #region DicStockType

            DicStockType[] stockTypes = { new DicStockType { Code = "stock", NameKk = "акции", NameRu = "акции" },
                                          new DicStockType { Code = "bond", NameKk = "облигации", NameRu = "облигации" },
                                          new DicStockType { Code = "bank certificates", NameKk = "банковские сертификаты", NameRu = "банковские сертификаты" },
                                          new DicStockType { Code = "bill", NameKk = "векселя", NameRu = "векселя" },
                                          new DicStockType { Code = "mortgage-certificates", NameKk = "ипотечные свидетельства", NameRu = "ипотечные свидетельства" },
                                          new DicStockType { Code = "other", NameKk = "другие", NameRu = "другие" }};

            foreach (DicStockType stockType in stockTypes)
            {
                if (!context.DicStockType.Where(x => x.Code.Equals(stockType.Code)).Any())
                {
                    context.DicStockType.Add(stockType);
                }
            }

            #endregion


            #region DicTransportBodyType

            DicTransportBodyType[] transportBodyTypes = {   new DicTransportBodyType { Code = "sedan"               , NameKk = "седан"                  , NameRu = "седан"              },
                                                            new DicTransportBodyType { Code = "station-wagon"       , NameKk = "универсал"              , NameRu = "универсал"          },
                                                            new DicTransportBodyType { Code = "hatchback"           , NameKk = "хэтчбек"                , NameRu = "хэтчбек"            },
                                                            new DicTransportBodyType { Code = "limousine"           , NameKk = "лимузин"                , NameRu = "лимузин"            },
                                                            new DicTransportBodyType { Code = "body-coupe"          , NameKk = "купе"                   , NameRu = "купе"               },
                                                            new DicTransportBodyType { Code = "body-roadster"       , NameKk = "родстер"                , NameRu = "родстер"            },
                                                            new DicTransportBodyType { Code = "cabriolet"           , NameKk = "кабриолет"              , NameRu = "кабриолет"          },
                                                            new DicTransportBodyType { Code = "suv"                 , NameKk = "жол талғамайтын көлік"  , NameRu = "внедорожник"        },
                                                            new DicTransportBodyType { Code = "crossover-suv"       , NameKk = "кроссовер"              , NameRu = "кроссовер"          },
                                                            new DicTransportBodyType { Code = "microvan"            , NameKk = "микровэн"               , NameRu = "микровэн"           },
                                                            new DicTransportBodyType { Code = "minivan"             , NameKk = "минивэн"                , NameRu = "минивэн"            },
                                                            new DicTransportBodyType { Code = "van"                 , NameKk = "микроавтобус"           , NameRu = "микроавтобус"       },
                                                            new DicTransportBodyType { Code = "wagon"               , NameKk = "фургон"                 , NameRu = "фургон"             },
                                                            new DicTransportBodyType { Code = "body-pickup"         , NameKk = "пикап"                  , NameRu = "пикап"              },
                                                            new DicTransportBodyType { Code = "targa"               , NameKk = "тарга"                  , NameRu = "тарга"              },
                                                            new DicTransportBodyType { Code = "fastback"            , NameKk = "фастбэк"                , NameRu = "фастбэк"            },
                                                            new DicTransportBodyType { Code = "liftback"            , NameKk = "лифтбэк"                , NameRu = "лифтбэк"            },
                                                            new DicTransportBodyType { Code = "hardtop"             , NameKk = "хардтоп"                , NameRu = "хардтоп"            }
};

            foreach (DicTransportBodyType transportBodyType in transportBodyTypes)
            {
                if (!context.DicTransportBodyType.Where(x => x.Code.Equals(transportBodyType.Code)).Any())
                {
                    context.DicTransportBodyType.Add(transportBodyType);
                }
            }

            #endregion


            #region DicTransportFuel

            DicTransportFuel[] transportFuels = { new DicTransportFuel { Code = "petrol", NameKk = "бензин", NameRu = "бензин" },
                                         new DicTransportFuel { Code = "diesel", NameKk = "дизель", NameRu = "дизель" },
                                         new DicTransportFuel { Code = "gas-petrol", NameKk = "газ-бензин", NameRu = "газ-бензин" },
                                         new DicTransportFuel { Code = "gas", NameKk = "газ", NameRu = "газ" },
                                         new DicTransportFuel { Code = "hybrid", NameKk = "гибрид", NameRu = "гибрид" },
                                         new DicTransportFuel { Code = "electricity", NameKk = "электр қуаты", NameRu = "электричество" }};

            foreach (DicTransportFuel transportFuel in transportFuels)
            {
                if (!context.DicTransportFuel.Where(x => x.Code.Equals(transportFuel.Code)).Any())
                {
                    context.DicTransportFuel.Add(transportFuel);
                }
            }

            #endregion


            #region DicTransportSteeringWheel

            DicTransportSteeringWheel[] transportSteeringWheels = { new DicTransportSteeringWheel { Code = "left"  , NameKk = "сол жақта" , NameRu = "слева"},
                                                                    new DicTransportSteeringWheel { Code = "right" , NameKk = "оң жақта"  , NameRu = "справа"}};

            foreach (DicTransportSteeringWheel transportSteeringWheel in transportSteeringWheels)
            {
                if (!context.DicTransportSteeringWheel.Where(x => x.Code.Equals(transportSteeringWheel.Code)).Any())
                {
                    context.DicTransportSteeringWheel.Add(transportSteeringWheel);
                }
            }

            #endregion


            #region DicTransportType

            DicTransportType[] transportTypes = { new DicTransportType { Code = "sedan"  , NameKk = "легковой" , NameRu = "легковой"},
                                                  new DicTransportType { Code = "cargo"  , NameKk = "грузовой" , NameRu = "грузовой"},
                                                  new DicTransportType { Code = "passenger" , NameKk = "пассажирский"  , NameRu = "пассажирский"}};

            foreach (DicTransportType transportType in transportTypes)
            {
                if (!context.DicTransportType.Where(x => x.Code.Equals(transportType.Code)).Any())
                {
                    context.DicTransportType.Add(transportType);
                }
            }

            #endregion


            #region DicWallMaterial

            DicWallMaterial[] wallMaterials = { new DicWallMaterial { Code = "sedan", NameKk = "монолит"                , NameRu = "монолит"                },
                                                new DicWallMaterial { Code = "sedan", NameKk = "панельный"              , NameRu = "панельный"              },
                                                new DicWallMaterial { Code = "sedan", NameKk = "пеноблок"               , NameRu = "пеноблок"               },
                                                new DicWallMaterial { Code = "sedan", NameKk = "деревянный брус"        , NameRu = "деревянный брус"        },
                                                new DicWallMaterial { Code = "sedan", NameKk = "крупноблок"             , NameRu = "крупноблок"             },
                                                new DicWallMaterial { Code = "sedan", NameKk = "железобетонный блок"    , NameRu = "железобетонный блок"    },
                                                new DicWallMaterial { Code = "sedan", NameKk = "керамзит"               , NameRu = "керамзит"               },
                                                new DicWallMaterial { Code = "sedan", NameKk = "шлакоблок"              , NameRu = "шлакоблок"              },
                                                new DicWallMaterial { Code = "sedan", NameKk = "газоблок"               , NameRu = "газоблок"               },
                                                new DicWallMaterial { Code = "sedan", NameKk = "саман"                  , NameRu = "саман"                  },
                                                new DicWallMaterial { Code = "sedan", NameKk = "сырцовый кирпич"        , NameRu = "сырцовый кирпич"        },
                                                new DicWallMaterial { Code = "sedan", NameKk = "дерево"                 , NameRu = "дерево"                 },
                                                new DicWallMaterial { Code = "sedan", NameKk = "сплитерный блок"        , NameRu = "сплитерный блок"        },
                                                new DicWallMaterial { Code = "sedan", NameKk = "сип панель"             , NameRu = "сип панель"             },
                                                new DicWallMaterial { Code = "sedan", NameKk = "каркасно-камышитовый"   , NameRu = "каркасно-камышитовый"   },
                                                new DicWallMaterial { Code = "sedan", NameKk = "сендвич-панели"         , NameRu = "сендвич-панели"         },
                                                new DicWallMaterial { Code = "sedan", NameKk = "каркасно-щитовой"       , NameRu = "каркасно-щитовой"       }};

            foreach (DicWallMaterial wallMaterial in wallMaterials)
            {
                if (!context.DicWallMaterial.Where(x => x.Code.Equals(wallMaterial.Code)).Any())
                {
                    context.DicWallMaterial.Add(wallMaterial);
                }
            }

            #endregion


            #region DicEquipmentPurpose

            DicGuaranteeType[] guaranteeTypes = { new DicGuaranteeType { Code = "government", NameKk = "гарантии и поручительства Правительства РК", NameRu = "гарантии и поручительства Правительства РК" },
                                                  new DicGuaranteeType { Code = "bank", NameKk = "гарантии БВУ в рамках лимита, установленного в соответствии с внутренними документами Общества", NameRu = "гарантии БВУ в рамках лимита, установленного в соответствии с внутренними документами Общества" },
                                                  new DicGuaranteeType { Code = "jur", NameKk = "гарантии юридических лиц, единственным акционером которых является государство в лице Правительства РК, либо национальный управляющий холдинг", NameRu = "гарантии юридических лиц, единственным акционером которых является государство в лице Правительства РК, либо национальный управляющий холдинг" },
                                                  new DicGuaranteeType { Code = "jur-government", NameKk = "гарантии юридических лиц, единственным акционером / учредителем которых является государство в лице акиматов городов республиканского значения, областных акиматов, принимаются при следующих ограничениях", NameRu = "гарантии юридических лиц, единственным акционером / учредителем которых является государство в лице акиматов городов республиканского значения, областных акиматов, принимаются при следующих ограничениях" }};

            foreach (DicGuaranteeType guaranteeType in guaranteeTypes)
            {
                if (!context.DicGuaranteeType.Where(x => x.Code.Equals(guaranteeType.Code)).Any())
                {
                    context.DicGuaranteeType.Add(guaranteeType);
                }
            }

            #endregion

            /*
            #region DicFileType

            DicFileType[] fileTypes = { new DicFileType { Code = "1", NameKz = "Удостоверение личности"                                             , NameRu = "Удостоверение личности"                                          },
                                        new DicFileType { Code = "2", NameKz = "Удостоверение личности супруги (-а)"                                , NameRu = "Удостоверение личности супруги (-а)"                             },
                                        new DicFileType { Code = "3", NameKz = "Свидетелство о заключении брака"                                    , NameRu = "Свидетелство о заключении брака"                                 },
                                        new DicFileType { Code = "4", NameKz = "Свидетельство о рождении ребенка"                                   , NameRu = "Свидетельство о рождении ребенка"                                },
                                        new DicFileType { Code = "5", NameKz = "Сертификата Национальной палаты предпринимателей «Атамекен»"        , NameRu = "Сертификата Национальной палаты предпринимателей «Атамекен»"     },
                                        new DicFileType { Code = "6", NameKz = "Сертификата о прохождении обучения основам предпринимательства"     , NameRu = "Сертификата о прохождении обучения основам предпринимательства"  },
                                        new DicFileType { Code = "7", NameKz = "Направление с центра занятости"                                     , NameRu = "Направление с центра занятости"                                  },
                                        new DicFileType { Code = "8", NameKz = "Справка о наличии текущего счета"                                   , NameRu = "Справка о наличии текущего счета"                                },
                                        new DicFileType { Code = "9", NameKz = "Справка о ветеринарно-санитарном благополучии"                      , NameRu = "Справка о ветеринарно-санитарном благополучии"                   },
                                        new DicFileType { Code = "10", NameKz = "Справка о зарегистрированных правах и обременениях не более чем за 20 календарных дней до даты подачи заявки"          , NameRu = "Справка о зарегистрированных правах и обременениях не более чем за 20 календарных дней до даты подачи заявки"        },
                                        new DicFileType { Code = "11", NameKz = "Технический паспорт на объект недвижимости"                                                                            , NameRu = "Технический паспорт на объект недвижимости"                                                                          },
                                        new DicFileType { Code = "12", NameKz = "договор купли продажи"                                                                                                 , NameRu = "договор купли продажи"                                                                                               },
                                        new DicFileType { Code = "13", NameKz = "договор приватизации"                                                                                                  , NameRu = "договор приватизации"                                                                                                },
                                        new DicFileType { Code = "14", NameKz = "договор мены"                                                                                                          , NameRu = "договор мены"                                                                                                        },
                                        new DicFileType { Code = "15", NameKz = "Свидетельство о регистрации транспортного средства (технический паспорт)"                                              , NameRu = "Свидетельство о регистрации транспортного средства (технический паспорт)"                                            },
                                        new DicFileType { Code = "16", NameKz = "Документ, подтверждающий исправленное техническое состояние автотранспорта"                                            , NameRu = "Документ, подтверждающий исправленное техническое состояние автотранспорта"                                          },
                                        new DicFileType { Code = "17", NameKz = "Справка органа Дорожной полиции"                                                                                       , NameRu = "Справка органа Дорожной полиции"                                                                                     },
                                        new DicFileType { Code = "18", NameKz = "Решение гаранта на предоставление гарантии в обеспечение исполнения обязательств Замещика перед Обществом"             , NameRu = "Решение гаранта на предоставление гарантии в обеспечение исполнения обязательств Замещика перед Обществом"           },
                                        new DicFileType { Code = "19", NameKz = "Договор банкоского счета"                                                                                              , NameRu = "Договор банкоского счета"                                                                                            },
                                        new DicFileType { Code = "20", NameKz = "Депозитный договор, подтверждающий размещение денег в банке"                                                           , NameRu = "Депозитный договор, подтверждающий размещение денег в банке"                                                         },
                                        new DicFileType { Code = "21", NameKz = "Бизнес План", NameRu = "Бизнес План" },
                                        new DicFileType { Code = "22", NameKz = "Акт осмотра места бизнеса", NameRu = "Акт осмотра места бизнеса" },
                                        new DicFileType { Code = "23", NameKz = "Заявление", NameRu = "Заявление" },
                                        new DicFileType { Code = "24", NameKz = "Анкета", NameRu = "Анкета" },
                                        new DicFileType { Code = "25", NameKz = "Опись", NameRu = "Опись" },
                                        new DicFileType { Code = "26", NameKz = "Юридическое заключение", NameRu = "Юридическое заключение" },
                                        new DicFileType { Code = "27", NameKz = "Решение кредитного комитета", NameRu = "Решение кредитного комитета" }};

            foreach (DicFileType fileType in fileTypes)
            {
                if (!context.DicFileTypes.Where(x => x.Code.Equals(fileType.Code)).Any())
                {
                    context.DicFileTypes.Add(fileType);
                }
            }

            #endregion
            */

            #region DicDocumentType

            DicDocumentType[] documentTypes = { new DicDocumentType { Code = "0", NameKk = "NoType", NameRu = "NoType" },
                                                new DicDocumentType { Code = "1", NameKk = "BorrowerDocuments", NameRu = "BorrowerDocuments" },
                                                new DicDocumentType { Code = "2", NameKk = "TitleDocument", NameRu = "TitleDocument" }};

            foreach (DicDocumentType documentType in documentTypes)
            {
                if (!context.DicDocumentTypes.Where(x => x.Code.Equals(documentType.Code)).Any())
                {
                    context.DicDocumentTypes.Add(documentType);
                }
            }

            #endregion


            context.SaveChanges();

        }

        public static void SeedLoanProducts(DataContext context)
        {
            //DeleteLoanProducts(context);
            #region DicLoanProducts
            DicLoanProduct[] loanProducts = { new DicLoanProduct { Code = "1", NameKk = "Мал шаруашылығы", NameRu = "Животноводства" },
                                             new DicLoanProduct { Code = "2", NameKk = "Өсімдік шаруашылығы", NameRu = "Растениеводство" },
                                             new DicLoanProduct { Code = "3", NameKk = "Кәсіпкерлік қызметті дамыту", NameRu = "Развитие предпринимательской деятельности" },
                new DicLoanProduct { Code = "4", NameKk = "Ауылшаруашылық өнімдерін сақтау және өңдеу", NameRu = "Хранение и переработка сельскохозяйственной продукции" }};

            foreach (DicLoanProduct val in loanProducts)
            {
                if (!context.DicLoanProducts.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicLoanProducts.Add(val);
                }
            }
            #endregion
            
            
            #region DicLoanRepaymentTypes
            DicLoanRepaymentType[] loanRepaymentTypes = { new DicLoanRepaymentType { Code = "1", NameKk = "ай сайын", NameRu = "ежемесячно" },
                                            new DicLoanRepaymentType { Code = "2", NameKk = "тоқсан сайын", NameRu = "ежеквартально" },
                                            new DicLoanRepaymentType { Code = "3", NameKk = "жарты жылда 1 (бір) рет", NameRu = "1 (один) раз в полгода" },
                                            new DicLoanRepaymentType { Code = "4", NameKk = "жылына 1 (бір) рет", NameRu = "1 (один) раз в год" },
                                            new DicLoanRepaymentType { Code = "5", NameKk = "транш мерзімінің соңында", NameRu = "в конце срока транша" }};

            foreach (DicLoanRepaymentType val in loanRepaymentTypes)
            {
                if (!context.DicLoanRepaymentTypes.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicLoanRepaymentTypes.Add(val);
                }
            }
            #endregion
            
            #region DicRegion
            DicRegion[] regions = { new DicRegion { Code = "1", NameKk = "Север", NameRu = "Север" },
                                            new DicRegion { Code = "2", NameKk = "Юг", NameRu = "Юг" },
                                            new DicRegion { Code = "3", NameKk = "Запад", NameRu = "Запад" },
                                            new DicRegion { Code = "4", NameKk = "Восток", NameRu = "Восток" },
                                            new DicRegion { Code = "5", NameKk = "Центр", NameRu = "Центр" },
                                            new DicRegion { Code = "6", NameKk = "Все", NameRu = "Все" },
                                            new DicRegion { Code = "7", NameKk = "Мангыстау", NameRu = "Мангыстау" }};

            foreach (var region in regions)
            {
                if (!context.DicRegions.Where(x => x.Code.Equals(region.Code)).Any())
                {
                    context.DicRegions.Add(region);
                }
            }
            #endregion
            #region DicClientLocationType
            DicClientLocationType[] clientLocationType = { new DicClientLocationType { Code = "1", NameKk = "Нұр-Сұлтан, Алматы, Шымкент, Ақтау, Атырау қалаларында", NameRu = "в городах Нур-Султан, Алматы, Шымкент, Актау, Атырау" },
                                            new DicClientLocationType { Code = "2", NameKk = "қалалар мен моноқалаларда (Нұр-Сұлтан, Алматы, Шымкент, Ақтау, Атырау қалаларынан басқа)", NameRu = "в городах и моногородах (кроме Нур-Султан, Алматы, Шымкент, Актау, Атырау)" },
                                            new DicClientLocationType { Code = "3", NameKk = "аылда және шағын қалаларда ", NameRu = "в селе и малых городах" },
                                            new DicClientLocationType { Code = "4", NameKk = "барлығы", NameRu = "все" }};
            foreach (DicClientLocationType val in clientLocationType)
            {
                if (!context.DicClientLocationTypes.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicClientLocationTypes.Add(val);
                }
            }
            #endregion
            #region DicClientSegment
            DicClientSegment[] clientSegmentes = { new DicClientSegment { Code = "1", NameKk = "АӘК", NameRu = "АСП" },
                                                new DicClientSegment { Code = "2", NameKk = "Көп балалы ", NameRu = "Многодетные" },
                                                new DicClientSegment { Code = "3", NameKk = "басқа", NameRu = "другие" }};

            foreach (DicClientSegment val in clientSegmentes)
            {
                if (!context.DicClientSegmentes.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicClientSegmentes.Add(val);
                }
            }
            #endregion
           
            #region DicClientType
            DicClientType[] cientTypes = { new DicClientType { Code = "1", NameKk = "ӘКК", NameRu = "СПК" },
                                                new DicClientType { Code = "2", NameKk = "ШҚ", NameRu = "КХ" },
                                                new DicClientType { Code = "3", NameKk = "ФҚ", NameRu = "ФХ" },
                                                new DicClientType { Code = "4", NameKk = "ЖК", NameRu = "ИП" },
                                                new DicClientType { Code = "5", NameKk = "Барлығы", NameRu = "Все" }};

            foreach (DicClientType val in cientTypes)
            {
                if (!context.DicClientTypes.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicClientTypes.Add(val);
                }
            }
            #endregion
        }
        private static void DeleteLoanProducts(DataContext context)
        {
            context.RemoveRange(context.DicLoanProducts.Where(x => x.Code == "3" || x.Code == "4"));
            context.SaveChanges();
        }

        public static void SeedBranches(DataContext context)
        {

            Branch[] branches = {
                new Branch(){ Id = new Guid("341C21AB-BC6A-4CE4-87D0-49CFA02A0578"), ParentId = null, NameKz = "", NameRu = "АО «Национальный управляющий холдинг «КазАгро»", CodeKato = "110000000" , CodeGBDFL = "1902"}
                ,new Branch() { Id = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), ParentId = new Guid("341C21AB-BC6A-4CE4-87D0-49CFA02A0578"), NameKz = "", NameRu = "АО «КазАгроФинанс»", CodeKato = "110000000", CodeGBDFL = "1902" }
                ,new Branch() { Id = new Guid("F0BF7860-ED00-4668-9A85-01B646F59F72"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Солтүстік Қазақстан филиалы", NameRu = "Солтүстік Қазақстан филиалы", CodeKato = "590000000", CodeGBDFL = "1948", CodeOCA = "0ЦА006", AddressKz = "Петропавл қ., Букетов к-сі, 31А", AddressRu = "г.Петропавловск, ул. Букетова 31А", Phone = "+7(7152)46-51-48", Code = "15" }
                ,new Branch() { Id = new Guid("6C457B83-ABDB-4A14-AFF7-07395D657BB5"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Ақмола филиалы",NameRu = "Ақмола филиалы", CodeKato = "110000000", CodeGBDFL = "1902", CodeOCA = "0ЦА014", AddressKz = "Көкшетау қ., Абай к-сі, 96, бөлімше. Нұр-сұлтан қ. Тұран к-сі 19/1 «Эдем» БО, 3 қабат", AddressRu = "г.Кокшетау, ул.Абая 96, Отделение. г. Нур-Султан ул. Туран 19/1 БЦ «Эдем» 3 этаж", Phone = "+7(7162)50-07-55, 87162-50-07-54", Code = "03" }
                ,new Branch() { Id = new Guid("7171D3BB-441F-4718-ACD3-4B825AF9F462"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Ақтөбе филиалы",NameRu = "Ақтөбе филиалы", CodeKato = "150000000", CodeGBDFL = "1904", CodeOCA = "0ЦА002", AddressKz = "Ақтөбе қ., Әбілқайыр хан даңғ., 51/1 (ғим.Даму), 16 кеңсе (2 қабат)", AddressRu = "г.Актобе, пр.Абылхаир хана 51/1(зд.Даму), 16 офис(2 этаж)", Phone = "+7(7132)908-319 вн.104", Code = "04" }
                ,new Branch() { Id = new Guid("5A7A4D9D-055C-41FF-8F98-54F12AAA8AFB"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Шығыс Қазақстан филиалы", NameRu = "Шығыс Қазақстан филиалы",CodeKato = "630000000", CodeGBDFL = "1917", CodeOCA = "0ЦА012", AddressKz = "Өскемен қаласы, Қабанбай батыр көшесі 87/2, 3-қабат, бөлімше. Семей қаласы, Мәңгілік Ел көшесі, 9, 204 кеңсе", AddressRu = "г.Усть-Каменогорск, ул. Кабанбай Батыра 87/2 ,3-этаж, Отделение. г.Семей, ул. Мангилик Ел, 9 офис 204", Phone = "+7(7232)70-10-09,+7(7222) 36-25-97, +7(7222) 36-28-37, +7(7222) 56-35-67, 8777-267-45-52", Code = "16" }
                ,new Branch() { Id = new Guid("FC49119F-7D5D-4663-8FF3-638462C0B770"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Павлодар филиалы",NameRu = "Павлодар филиалы", CodeKato = "550000000", CodeGBDFL = "1945", CodeOCA = "0ЦА011", AddressKz = "Павлодар қ., Луговая к-сі 16", AddressRu = "г.Павлодар, ул.Луговая 16", Phone = "+7(7182)62-12-22", Code = "14" }
                ,new Branch() { Id = new Guid("AD0C6B6A-FE83-49A9-B187-75C318D6C8BD"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Жамбыл филиалы",NameRu = "Жамбыл филиалы", CodeKato = "310000000", CodeGBDFL = "1919", CodeOCA = "0ЦА015", AddressKz = "Тараз қаласы, Төле би даңғылы, 93 А", AddressRu = "г.Тараз, пр.Толе би, 93 А", Phone = "+7(7262)-54-60-45", Code = "08" }
                ,new Branch() { Id = new Guid("F7627203-2AC3-434B-BDA3-7DA8D597049D"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Қарағанды филиалы", NameRu = "Қарағанды филиалы", CodeKato = "350000000", CodeGBDFL = "1930", CodeOCA = "0ЦА009", AddressKz = "Қарағанды қ., Шахтеров даңғ., 40 құрылыс", AddressRu = "г.Караганда, пр.Шахтеров, строение 40", Phone = "+7(7212)21-14-15", Code = "09" }
                ,new Branch() { Id = new Guid("A9385562-6D6B-45D5-AA76-8F024FC41C7B"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Түркістан филиалы",NameRu = "Түркістан филиалы", CodeKato = "610000000", CodeGBDFL = "1917", CodeOCA = "0ЦА007", AddressKz = "Шымкент қ., Әл-Фараби ауданы, Д. Қонаев д-лы, ғим. 3/3, 2 қабат, бөлімше. Түркістан қаласы, С. Қожанов көшесі, №25/1 үй", AddressRu = "г.Шымкент, Аль-Фарабийский район, пр.Д.Кунаева, зд. 3/3, 2 этаж, Отделение. г.Туркестан, ул. С.Кожанова, дом №25/1", Phone = "+7(7253)33-23-18,+7(7253) 35-93-28", Code = "13" }
                ,new Branch() { Id = new Guid("CE2F5A82-CA82-4CAB-AB9A-975E37479847"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Қостанай филиалы",NameRu = "Қостанай филиалы", CodeKato = "390000000", CodeGBDFL = "1937", CodeOCA = "0ЦА004", AddressKz = "Қостанай қ., Әл-Фараби даңғ., 65 3 қабат", AddressRu = "г.Костанай, пр.Аль -Фараби, 65 3 этаж", Phone = "+7(7142)53-39-16", Code = "10" }
                ,new Branch() { Id = new Guid("D31B2010-4D9F-40E3-9D0B-9EEB073983EA"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Алматы филиалы",NameRu = "Алматы филиалы", CodeKato = "190000000", CodeGBDFL = "1907", CodeOCA = "0ЦА005", AddressKz = "Алматы қ., Медеу ауданы, Қабанбай батыр көшесі 51/78, ВП 65 (Қалдаяқов көшесінің қиылысы), бөлімше. Алматы обл.", AddressRu = "г.Алматы, Медеуский р-он, ул.Кабанбай батыра 51/78, ВП65(угол ул.Калдаякова), Отделение. Алматинская обл., г. Талдыкорган, ул. Желтоксан, 205", Phone = "+7(727)334-19-68, 8 (728) 22-00-99 8 (728) 24-20-21 ", Code = "05" }
                ,new Branch() { Id = new Guid("57C8A225-E379-4CE3-84E9-C6D3CB1A7F4E"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Атырау филиалы",NameRu = "Атырау филиалы", CodeKato = "230000000", CodeGBDFL = "1915", CodeOCA = "0ЦА003", AddressKz = "Атырау қ., Сәтпаев к-сі, 13а, 3 қабат", AddressRu = "г.Атырау, ул.Сатпаева 13А, 3 этаж", Phone = "+7(7122)50-83-16", Code = "06" }
                ,new Branch() { Id = new Guid("9388ABA2-F08A-4773-87EF-F5C4C28AFAB5"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Батыс Қазақстан филиалы",NameRu = "Батыс Қазақстан филиалы", CodeKato = "270000000", CodeGBDFL = "1926", CodeOCA = "0ЦА010", AddressKz = "Орал қаласы. Ықсанов Көшесі 38", AddressRu = "г.Уральск. Ул.Ихсанова 38", Phone = "+7(7112)24-15-26", Code = "07" }
                ,new Branch() { Id = new Guid("C813068D-B17E-49C6-82AA-FA8EF243B5C6"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Маңғыстау филиалы",NameRu = "Маңғыстау филиалы", CodeKato = "470000000", CodeGBDFL = "1943", CodeOCA = "0ЦА013", AddressKz = "Ақтау Қ., 16 ш / а, «Қайсар» БО, 2-қабат", AddressRu = "г.Актау, 16 мкр, БЦ «Кайса», 2-этаж", Phone = "+7(7292)30-43-42", Code = "12" }
                ,new Branch() { Id = new Guid("D555869B-A091-48D5-AB1B-FE2582FD9189"), ParentId = new Guid("50613B03-A05A-49F3-A383-222DEFD963E4"), NameKz = "Қызылорда филиалы",NameRu = "Қызылорда филиалы", CodeKato = "430000000", CodeGBDFL = "1933", CodeOCA = "0ЦА001", AddressKz = "Қызылорда қаласы, Дінмұхамед Қонаев көшесі, 41", AddressRu = "г.Кызылорда, ул.Динмухамед Конаев 41", Phone = "+7(7242)26-20-80", Code = "11" }

            };


            foreach (Branch branch in branches)
            {
                if (!context.Branches.Where(x => x.ParentId.Equals(branch.ParentId) && x.Code.Equals(branch.Code)).Any())
                {
                    context.Branches.Add(branch);
                }
            }

            context.SaveChanges();

        }

        public static void SeedLoanHistoryStatus(DataContext context)
        {
            DicLoanHistoryStatus[] statuses =
                {
                    new DicLoanHistoryStatus(){Code="FinancialAnalysis", NameKk="", NameRu="Финансовый анализ" },
                    new DicLoanHistoryStatus(){Code="ManagerForm", NameKk="", NameRu="Кредитный менеджер" },
                    new DicLoanHistoryStatus(){Code="InspectorBusinessPlace", NameKk="", NameRu="Специалист по осмотру места бизнеса" },
                    new DicLoanHistoryStatus(){Code="HeadPledgeExpertise", NameKk="", NameRu="Руководитель залоговых экспертов" },
                    new DicLoanHistoryStatus(){Code="PledgeExpertise", NameKk="", NameRu="Залоговая экспертиза" },
                    new DicLoanHistoryStatus(){Code="HeadDueExpertise", NameKk="", NameRu="Руководитель юристов" },
                    new DicLoanHistoryStatus(){Code="DueExpertise", NameKk="", NameRu="Юридическая экспертиза" },
                    new DicLoanHistoryStatus(){Code="EliminateLaywerRemark", NameKk="", NameRu="Устранения замечаний. Кредитный менеджер" },
                    new DicLoanHistoryStatus(){Code="CreditCommitteeFrom1", NameKk="", NameRu="Кредитный комитет1" },
                    new DicLoanHistoryStatus(){Code="CreditCommitteeFrom2", NameKk="", NameRu="Кредитный комитет2" },
                    new DicLoanHistoryStatus(){Code="CreditCommitteeFrom3", NameKk="", NameRu="Кредитный комитет3" },
                    new DicLoanHistoryStatus(){Code="PrepareCreditDossier", NameKk="", NameRu="Формирование кредитного досье для передачи в 1С" },
                    new DicLoanHistoryStatus(){Code="RejectFinancialAnalysis", NameKk="", NameRu="Отказано. Финансовый анализ" },
                    new DicLoanHistoryStatus(){Code="Completed", NameKk="", NameRu="Завершено" },
                    new DicLoanHistoryStatus(){Code="RejectCreditCommittee", NameKk="", NameRu="Отказано. Кредитный комитет" },
                    new DicLoanHistoryStatus(){Code="Registration", NameKk="", NameRu="Регистрация" },
                    new DicLoanHistoryStatus(){Code="CheckCreditDossier", NameKk="", NameRu="Проверка кредитного досье. Кредитный администратор" }
                };
            foreach (DicLoanHistoryStatus val in statuses)
            {
                if (!context.DicLoanHistoryStatuses.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicLoanHistoryStatuses.Add(val);
                }
            }

            context.SaveChanges();
        }

        public static void SeedDocClassificationDictionary(DataContext context)
        {
            #region DicDocClassification

            DicDocClassification[] docClassifications = {
                                    new DicDocClassification { Code = "1", NameKk = "Для Индивидуальных предпринимателей", NameRu = "Для Индивидуальных предпринимателей", ParagraphNumber = 6 },
                                    new DicDocClassification { Code = "2", NameKk = "Для Крестьянских (фермерских) хозяйств", NameRu = "Для Крестьянских (фермерских) хозяйств", ParagraphNumber = 7 },
                                    new DicDocClassification { Code = "3", NameKk = "Документы физических лиц", NameRu = "Документы физических лиц", ParagraphNumber = 8 },
                                    new DicDocClassification { Code = "4", NameKk = "Документы при передаче в залог квартиры, встроенного помещения без земельного участка и без входной группы", NameRu = "Документы при передаче в залог квартиры, встроенного помещения без земельного участка и без входной группы", ParagraphNumber = 9 },
                                    new DicDocClassification { Code = "5", NameKk = "Документы при передаче в залог земельного участка или права землепользования, на котором отсутствуют строения", NameRu = "Документы при передаче в залог земельного участка или права землепользования, на котором отсутствуют строения", ParagraphNumber = 10 },
                                    new DicDocClassification { Code = "6", NameKk = "Документы при передаче в залог жилого дома или нежилых помещений с земельным участком или правом землепользования", NameRu = "Документы при передаче в залог жилого дома или нежилых помещений с земельным участком или правом землепользования", ParagraphNumber = 11 },
                                    new DicDocClassification { Code = "7", NameKk = "Документы при передаче в залог земельного участка или права землепользования с объектом незавершенного строительства", NameRu = "Документы при передаче в залог земельного участка или права землепользования с объектом незавершенного строительства", ParagraphNumber = 12 },
                                    new DicDocClassification { Code = "8", NameKk = "Документы при передаче в залог транспортных средств, сельскохозяйственной, дорожно-строительной, горной и другой специальной техники или судов, или подвижного состава", NameRu = "Документы при передаче в залог транспортных средств, сельскохозяйственной, дорожно-строительной, горной и другой специальной техники или судов, или подвижного состава", ParagraphNumber = 13 },
                                    new DicDocClassification { Code = "9", NameKk = "Документы при передаче в залог товаров в обороте", NameRu = "Документы при передаче в залог товаров в обороте", ParagraphNumber = 14 },
                                    new DicDocClassification { Code = "10", NameKk = "Документы при передаче в залог зерна", NameRu = "Документы при передаче в залог зерна", ParagraphNumber = 15 },
                                    new DicDocClassification { Code = "11", NameKk = "Документы при передаче в залог устройств и оборудования", NameRu = "Документы при передаче в залог устройств и оборудования", ParagraphNumber = 16 },
                                    new DicDocClassification { Code = "12", NameKk = "Документы при передаче в залог денег", NameRu = "Документы при передаче в залог денег", ParagraphNumber = 18 },
                                    new DicDocClassification { Code = "13", NameKk = "Документы при передаче в залог сельскохозяйственных животных", NameRu = "Документы при передаче в залог сельскохозяйственных животных", ParagraphNumber = 20 },
                                    new DicDocClassification { Code = "14", NameKk = "Документы при передаче в залог имущества, поступающего в собственность залогодателя в будущем", NameRu = "Документы при передаче в залог имущества, поступающего в собственность залогодателя в будущем", ParagraphNumber = 21 },
                                    new DicDocClassification { Code = "15", NameKk = "Документы при передаче в залог прав требований", NameRu = "Документы при передаче в залог прав требований", ParagraphNumber = 22 } };

            foreach (DicDocClassification docClassification in docClassifications)
            {
                if (!context.DicDocClassifications.Where(x => x.Code.Equals(docClassification.Code)).Any())
                {
                    context.DicDocClassifications.Add(docClassification);
                }
            }

            #endregion
            context.SaveChanges();

            #region DicClassificationSubtitle


            List<DicClassificationSubtitle> cs = new List<DicClassificationSubtitle>();

            if (context.DicDocClassifications.Where(x => x.Code.Equals("1")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("1")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "1", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Документ, удостоверяющий личность индивидуального предпринимателя", NameRu = "Документ, удостоверяющий личность индивидуального предпринимателя" });
                cs.Add(new DicClassificationSubtitle { Code = "2", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Документ установленной формы, выданный регистрирующим органом, подтверждающий факт прохождения государственной регистрации в качестве индивидуального предпринимателя", NameRu = "Документ установленной формы, выданный регистрирующим органом, подтверждающий факт прохождения государственной регистрации в качестве индивидуального предпринимателя" });
                cs.Add(new DicClassificationSubtitle { Code = "3", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги(-а)", NameRu = "Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги(-а)" });
                cs.Add(new DicClassificationSubtitle { Code = "4", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Нотариально удостоверенные сведения о семейном положении ИП – залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) ИП – залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами", NameRu = "Нотариально удостоверенные сведения о семейном положении ИП – залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) ИП – залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("2")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("2")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "5", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Документ, удостоверяющий личность главы крестьянского (фермерского) хозяйства", NameRu = "Документ, удостоверяющий личность главы крестьянского (фермерского) хозяйства" });
                cs.Add(new DicClassificationSubtitle { Code = "6", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Документ установленной формы, выданный регистрирующим органом, подтверждающий факт прохождения государственной регистрации в качестве крестьянского (фермерского) хозяйства", NameRu = "Документ установленной формы, выданный регистрирующим органом, подтверждающий факт прохождения государственной регистрации в качестве крестьянского (фермерского) хозяйства" });
                cs.Add(new DicClassificationSubtitle { Code = "7", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Справка, выданная местным исполнительным органом (по месту регистрации крестьянского (фермерского) хозяйства, о составе/членах крестьянского (фермерского) хозяйства К свидетельству о государственной регистрации совместного индивидуального предпринимательства прилагается список его членов, заверенный органом государственных доходов", NameRu = "Справка, выданная местным исполнительным органом (по месту регистрации крестьянского (фермерского) хозяйства, о составе/членах крестьянского (фермерского) хозяйства К свидетельству о государственной регистрации совместного индивидуального предпринимательства прилагается список его членов, заверенный органом государственных доходов" });
                cs.Add(new DicClassificationSubtitle { Code = "8", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Правоустанавливающий и идентификационный (акт на право частной собственности/право временного возмездного землепользования) документы на земельный участок/право землепользования", NameRu = "Правоустанавливающий и идентификационный (акт на право частной собственности/право временного возмездного землепользования) документы на земельный участок/право землепользования" });
                cs.Add(new DicClassificationSubtitle { Code = "9", DocClassificationId = dguid, ParagraphNumber = 5, NameKk = "Для крестьянских (фермерских) хозяйств, созданных на основе личного предпринимательства: Нотариально удостоверенные сведения о семейном положении главы КХ (ФХ) – залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) главы КХ (ФХ) – залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами, Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги (-а)", NameRu = "Для крестьянских (фермерских) хозяйств, созданных на основе личного предпринимательства: Нотариально удостоверенные сведения о семейном положении главы КХ (ФХ) – залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) главы КХ (ФХ) – залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами, Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги (-а)" });
                cs.Add(new DicClassificationSubtitle { Code = "10", DocClassificationId = dguid, ParagraphNumber = 6, NameKk = "Для крестьянских (фермерских) хозяйств, созданных в форме семейного предпринимательства, или простого товарищества: Решение общего собрания участников крестьянского хозяйства или простого товарищества о заключении кредитного договора и (или) договора об обеспечении на условиях Общества, с указанием суммы, срока займа или гарантии, о предоставлении в залог имущества или предоставлении гарантии, с предоставлением Обществу права безакцептного списания денег или на внесудебную реализацию имущества в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, с указанием лица, уполномоченного на подписание договоров и иных необходимых документов с нотариально засвидетельствованными подписями лиц, принимающих решение. 1. Доверенность, выданная членами крестьянского (фермерского) хозяйства, основанного в форме семейного предпринимательства, на имя его главы на представление интересов во взаимоотношениях с третьими лицами, с правом распоряжения имуществом КХ (ФХ) или 1.Доверенность, выданная членами простого товарищества на имя одного из товарищей на представление интересов товарищества во взаимоотношениях с Обществом, с правом распоряжения имуществом простого товарищества. 2.Договор о совместной деятельности", NameRu = "Для крестьянских (фермерских) хозяйств, созданных в форме семейного предпринимательства, или простого товарищества: Решение общего собрания участников крестьянского хозяйства или простого товарищества о заключении кредитного договора и (или) договора об обеспечении на условиях Общества, с указанием суммы, срока займа или гарантии, о предоставлении в залог имущества или предоставлении гарантии, с предоставлением Обществу права безакцептного списания денег или на внесудебную реализацию имущества в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, с указанием лица, уполномоченного на подписание договоров и иных необходимых документов с нотариально засвидетельствованными подписями лиц, принимающих решение. 1. Доверенность, выданная членами крестьянского (фермерского) хозяйства, основанного в форме семейного предпринимательства, на имя его главы на представление интересов во взаимоотношениях с третьими лицами, с правом распоряжения имуществом КХ (ФХ) или 1.Доверенность, выданная членами простого товарищества на имя одного из товарищей на представление интересов товарищества во взаимоотношениях с Обществом, с правом распоряжения имуществом простого товарищества. 2.Договор о совместной деятельности" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("3")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("3")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "11", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Документ, удостоверяющий личность", NameRu = "Документ, удостоверяющий личность" });
                cs.Add(new DicClassificationSubtitle { Code = "12", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги(-а).", NameRu = "Свидетельство о заключении брака (при наличии), Документ, удостоверяющий личность супруги(-а)." });
                cs.Add(new DicClassificationSubtitle { Code = "13", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Свидетельство о рождении или документ, удостоверяющий личность несовершеннолетних лиц (в случае если залогодателями являются несовершеннолетние дети)", NameRu = "Свидетельство о рождении или документ, удостоверяющий личность несовершеннолетних лиц (в случае если залогодателями являются несовершеннолетние дети)" });
                cs.Add(new DicClassificationSubtitle { Code = "14", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Документ, подтверждающий разрешение (согласие) органов опеки и попечительства на передачу недвижимого имущества в залог и внесудебную реализацию (если собственником недвижимого имущества являются несовершеннолетние лица и лица, признанные судом недееспособными (ограниченно дееспособными))", NameRu = "Документ, подтверждающий разрешение (согласие) органов опеки и попечительства на передачу недвижимого имущества в залог и внесудебную реализацию (если собственником недвижимого имущества являются несовершеннолетние лица и лица, признанные судом недееспособными (ограниченно дееспособными))" });
                cs.Add(new DicClassificationSubtitle { Code = "15", DocClassificationId = dguid, ParagraphNumber = 5, NameKk = "Нотариально удостоверенные сведения о семейном положении  залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами", NameRu = "Нотариально удостоверенные сведения о семейном положении  залогодателя или гаранта на момент приобретения и предоставления имущества в залог или предоставления гарантии или нотариально удостоверенное заявление супруга (-и) залогодателя или гаранта о согласии на залог имущества или предоставление гарантии с предоставлением Обществу права на внесудебную реализацию имущества или безакцептного списания денег в случае  неисполнения/ненадлежащего исполнения должником обязательств перед Обществом, если иное не предусмотрено законодательством РК, брачным договором или иным соглашением между супругами" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("4")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("4")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "16", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа о регистрации права собственности либо уведомление уполномоченного органа об электронной регистрации (договоры купли-продажи, мены, дарения, приватизации, свидетельство о праве на наследство, решения суда о признании права собственности, акты приемочных комиссий о приемке в эксплуатацию построенных объектов, решения о легализации, акты уполномоченных государственных органов и прочее). Акт приема-передачи (если предусмотрен правоустанавливающим документом). (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа о регистрации права собственности либо уведомление уполномоченного органа об электронной регистрации (договоры купли-продажи, мены, дарения, приватизации, свидетельство о праве на наследство, решения суда о признании права собственности, акты приемочных комиссий о приемке в эксплуатацию построенных объектов, решения о легализации, акты уполномоченных государственных органов и прочее). Акт приема-передачи (если предусмотрен правоустанавливающим документом). (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "17", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Технический паспорт/план. Заключение уполномоченного государственного органа об изменении общей / полезной(жилой) площади(при наличии).", NameRu = "Технический паспорт/план. Заключение уполномоченного государственного органа об изменении общей / полезной(жилой) площади(при наличии)." });
                cs.Add(new DicClassificationSubtitle { Code = "18", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документ, подтверждающий оплату стоимости предлагаемого в залог имущества (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости предлагаемого в залог имущества (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "19", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("5")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("5")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "20", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа о регистрации права собственности или права землепользования либо уведомление уполномоченного органа об электронной регистрации (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: - решение уполномоченного государственного органа о предоставлении права частной собственности или права землепользования, - договор купли-продажи земельного участка или договор аренды, Акт приема-передачи (если предусмотрен правоустанавливающим документом) (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа о регистрации права собственности или права землепользования либо уведомление уполномоченного органа об электронной регистрации (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: - решение уполномоченного государственного органа о предоставлении права частной собственности или права землепользования, - договор купли-продажи земельного участка или договор аренды, Акт приема-передачи (если предусмотрен правоустанавливающим документом) (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "21", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды).", NameRu = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды)." });
                cs.Add(new DicClassificationSubtitle { Code = "22", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "23", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("6")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("6")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "24", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа либо уведомление уполномоченного органа об электронной регистрации о регистрации права собственности или права землепользования (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов, и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: - решение уполномоченного органа о предоставлении права частной собственности или права землепользования, - договор купли-продажи земельного участка или договор аренды, Акт приема-передачи (если предусмотрен правоустанавливающим документом) (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа либо уведомление уполномоченного органа об электронной регистрации о регистрации права собственности или права землепользования (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов, и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: - решение уполномоченного органа о предоставлении права частной собственности или права землепользования, - договор купли-продажи земельного участка или договор аренды, Акт приема-передачи (если предусмотрен правоустанавливающим документом) (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "25", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды).", NameRu = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды)." });
                cs.Add(new DicClassificationSubtitle { Code = "26", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "27", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Технический паспорт на жилой дом или нежилое помещение. Заключение уполномоченного государственного органа об изменении общей / полезной(жилой) площади(при наличии).", NameRu = "Технический паспорт на жилой дом или нежилое помещение. Заключение уполномоченного государственного органа об изменении общей / полезной(жилой) площади(при наличии)." });
                cs.Add(new DicClassificationSubtitle { Code = "28", DocClassificationId = dguid, ParagraphNumber = 5, NameKk = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "29", DocClassificationId = dguid, ParagraphNumber = 6, NameKk = "Для имущественных комплексов (нефтебаза, АЗС, ХПП, иные) дополнительно: 1.документы, подтверждающие возникновение права собственности на оборудование, а также подтверждающие оплату его стоимости(для АЗС, в том числе – на топливораздаточные колонки и резервуары для хранения нефтепродуктов); 2.спецификации оборудования; 3.технические паспорта на оборудование; 4.акт обследования ХПП на предмет соответствия квалификационным требованиям", NameRu = "Для имущественных комплексов (нефтебаза, АЗС, ХПП, иные) дополнительно: 1.документы, подтверждающие возникновение права собственности на оборудование, а также подтверждающие оплату его стоимости(для АЗС, в том числе – на топливораздаточные колонки и резервуары для хранения нефтепродуктов); 2.спецификации оборудования; 3.технические паспорта на оборудование; 4.акт обследования ХПП на предмет соответствия квалификационным требованиям" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("7")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("7")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "30", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа или уведомление об электронной регистрации права собственности или права землепользования (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: -решение уполномоченного государственного органа о предоставлении права частной собственности или права землепользования, -договор купли - продажи земельного участка или договор аренды, Акт приема - передачи(если предусмотрен правоустанавливающим документом)(в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Правоустанавливающий документ с отметкой уполномоченного государственного регистрирующего органа или уведомление об электронной регистрации права собственности или права землепользования (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, решения о легализации, акты уполномоченных государственных органов и прочее). В том числе, в случае, если залогодатель является первичным собственником или землепользователем: -решение уполномоченного государственного органа о предоставлении права частной собственности или права землепользования, -договор купли - продажи земельного участка или договор аренды, Акт приема - передачи(если предусмотрен правоустанавливающим документом)(в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "31", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды).", NameRu = "Идентификационный документ на земельный участок (Акт на право частной собственности на земельный участок или Акт на право временного возмездного (долгосрочного, краткосрочного) землепользования (аренды)." });
                cs.Add(new DicClassificationSubtitle { Code = "32", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "33", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись).", NameRu = "Справка о зарегистрированных правах (обременениях) на недвижимое имущество и его технических характеристиках (в случае, если указанные документы не предоставлены экспертиза по обеспечению не проводится, о чем в заключении производится запись)." });
                cs.Add(new DicClassificationSubtitle { Code = "34", DocClassificationId = dguid, ParagraphNumber = 5, NameKk = "На незавершенное строительство: 1.проектно – сметная документация, 2.разрешение на производство строительно - монтажных работ или уведомление органов, осуществляющих государственный архитектурно - строительный контроль и надзор, о начале производства строительно - монтажных работ; 3.договоры купли – продажи, поставки, иные договоры о приобретении строительных материалов, 4.документы, подтверждающие оплату стоимости строительных материалов, 5.акт выполненных работ, 6.справка о стоимости выполненных работ, 7.графики производства работ ", NameRu = "На незавершенное строительство: 1.проектно – сметная документация, 2.разрешение на производство строительно - монтажных работ или уведомление органов, осуществляющих государственный архитектурно - строительный контроль и надзор, о начале производства строительно - монтажных работ; 3.договоры купли – продажи, поставки, иные договоры о приобретении строительных материалов, 4.документы, подтверждающие оплату стоимости строительных материалов, 5.акт выполненных работ, 6.справка о стоимости выполненных работ, 7.графики производства работ " });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("8")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("8")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "35", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, прочее). Акт приема - передачи(если предусмотрен правоустанавливающим документом) Спецификация(если предусмотрена правоустанавливающим документом)", NameRu = "Правоустанавливающий документ (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, прочее). Акт приема - передачи(если предусмотрен правоустанавливающим документом) Спецификация(если предусмотрена правоустанавливающим документом)" });
                cs.Add(new DicClassificationSubtitle { Code = "36", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Технический паспорт (для с/х техники), Свидетельство о государственной регистрации транспортного средства (для автотранспорта), Свидетельство о праве плавания морского судна под Государственным флагом Республики Казахстан и свидетельство о праве собственности на судно/свидетельство о временном предоставлении права плавания под Государственным флагом Республики Казахстан (для морских судов), Судовое свидетельство/свидетельство о временном предоставлении права плавания под Государственным флагом Республики Казахстан (для речных судов), Регистрационная карточка (для маломерных судов), Свидетельство о регистрации подвижного состава", NameRu = "Технический паспорт (для с/х техники), Свидетельство о государственной регистрации транспортного средства (для автотранспорта), Свидетельство о праве плавания морского судна под Государственным флагом Республики Казахстан и свидетельство о праве собственности на судно/свидетельство о временном предоставлении права плавания под Государственным флагом Республики Казахстан (для морских судов), Судовое свидетельство/свидетельство о временном предоставлении права плавания под Государственным флагом Республики Казахстан (для речных судов), Регистрационная карточка (для маломерных судов), Свидетельство о регистрации подвижного состава" });
                cs.Add(new DicClassificationSubtitle { Code = "37", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "38", DocClassificationId = dguid, ParagraphNumber = 4, NameKk = "Таможенная декларация или декларация на товары, в случае ввоза транспортного средства (техники, морских, речных судов, подвижного состава) на территорию РК", NameRu = "Таможенная декларация или декларация на товары, в случае ввоза транспортного средства (техники, морских, речных судов, подвижного состава) на территорию РК" });
                cs.Add(new DicClassificationSubtitle { Code = "39", DocClassificationId = dguid, ParagraphNumber = 5, NameKk = "Сведения государственного регистрирующего органа о наличии (отсутствии) обременений на транспортное средство (технику, морские, речные суда, подвижной состав).", NameRu = "Сведения государственного регистрирующего органа о наличии (отсутствии) обременений на транспортное средство (технику, морские, речные суда, подвижной состав)." });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("9")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("9")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "40", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Складская справка о наличии товаров, предлагаемых в залог, с указанием наименований, идентификационных характеристик, количества и стоимости, заверенная печатью (при наличии), подписанная первым руководителем и главным бухгалтером (при наличии)", NameRu = "Складская справка о наличии товаров, предлагаемых в залог, с указанием наименований, идентификационных характеристик, количества и стоимости, заверенная печатью (при наличии), подписанная первым руководителем и главным бухгалтером (при наличии)" });
                cs.Add(new DicClassificationSubtitle { Code = "41", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Документ, подтверждающий оплату стоимости земельного участка.", NameRu = "Документ, подтверждающий оплату стоимости земельного участка." });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("10")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("10")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "42", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Выписка из лицевого счета владельца зерновой расписки", NameRu = "Выписка из лицевого счета владельца зерновой расписки" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("11")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("11")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "43", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Правоустанавливающий документ (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, прочее). Акт приема - передачи(если предусмотрен правоустанавливающим документом) Спецификация(если предусмотрена правоустанавливающим документом) Счета - фактуры или инвойсы", NameRu = "Правоустанавливающий документ (договоры купли-продажи, мены, дарения, свидетельство о праве на наследство, решения суда о признании права собственности, прочее). Акт приема - передачи(если предусмотрен правоустанавливающим документом) Спецификация(если предусмотрена правоустанавливающим документом) Счета - фактуры или инвойсы" });
                cs.Add(new DicClassificationSubtitle { Code = "44", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)", NameRu = "Документ, подтверждающий оплату стоимости земельного участка (в случае если, правоустанавливающим документом установлено, что оплата стоимости предлагаемого в залог имущества произведена в полном объеме при этом истек срок исковой давности, предоставление данного документа не требуется)" });
                cs.Add(new DicClassificationSubtitle { Code = "45", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Таможенная декларация или декларация на товары, в случае ввоза оборудования на территорию РК", NameRu = "Таможенная декларация или декларация на товары, в случае ввоза оборудования на территорию РК" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("12")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("12")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "46", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Договор Банковского вклада", NameRu = "Договор Банковского вклада" });
                cs.Add(new DicClassificationSubtitle { Code = "47", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Выписка со счета о наличии и движении денег на счете", NameRu = "Выписка со счета о наличии и движении денег на счете" });
                cs.Add(new DicClassificationSubtitle { Code = "48", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Дополнительное соглашение к договору банковского вклада, банковского счета", NameRu = "Дополнительное соглашение к договору банковского вклада, банковского счета" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("13")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("13")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "49", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Перечень с указанием вида, породы, возраста, количества, общего живого веса, стоимости животных (заверенный печатью и подписью первым руководителем и главным бухгалтером залогодателя – юридического лица/подписью залогодателя – физического лица);", NameRu = "Перечень с указанием вида, породы, возраста, количества, общего живого веса, стоимости животных (заверенный печатью и подписью первым руководителем и главным бухгалтером залогодателя – юридического лица/подписью залогодателя – физического лица);" });
                cs.Add(new DicClassificationSubtitle { Code = "50", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Племенное свидетельство (при наличии);", NameRu = "Племенное свидетельство (при наличии);" });
                cs.Add(new DicClassificationSubtitle { Code = "51", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Ветеринарные паспорта;", NameRu = "Ветеринарные паспорта;" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("14")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("14")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "52", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Договоры (соглашения, контракты), подтверждающие поступление имущества в будущем, спецификации, накладные, инвойсы, счета на оплату;", NameRu = "Договоры (соглашения, контракты), подтверждающие поступление имущества в будущем, спецификации, накладные, инвойсы, счета на оплату;" });
                cs.Add(new DicClassificationSubtitle { Code = "53", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Спецификация машин, оборудования (техническая документация поставщика, гарантии поставщика, справочные данные по техническому оборудованию)", NameRu = "Спецификация машин, оборудования (техническая документация поставщика, гарантии поставщика, справочные данные по техническому оборудованию)" });
                cs.Add(new DicClassificationSubtitle { Code = "54", DocClassificationId = dguid, ParagraphNumber = 3, NameKk = "Документы, подтверждающие оплату по договорам (контрактам, соглашениям), (при наличии)", NameRu = "Документы, подтверждающие оплату по договорам (контрактам, соглашениям), (при наличии)" });
            }
            if (context.DicDocClassifications.Where(x => x.Code.Equals("15")).Any())
            {
                Guid dguid = context.DicDocClassifications.Where(x => x.Code.Equals("15")).FirstOrDefault().Id;
                cs.Add(new DicClassificationSubtitle { Code = "55", DocClassificationId = dguid, ParagraphNumber = 1, NameKk = "Документ, подтверждающий совершение сделки, исполнение определенных условий которой является основанием возникновения прав требования (документ/отметка, подтверждающая регистрацию такой сделки, если регистрация требуется в соответствии с законодательством РК; отметка, подтверждающая нотариальное удостоверение такой сделки, если нотариальное удостоверение требуется в соответствии с законодательством или соглашением сторон)", NameRu = "Документ, подтверждающий совершение сделки, исполнение определенных условий которой является основанием возникновения прав требования (документ/отметка, подтверждающая регистрацию такой сделки, если регистрация требуется в соответствии с законодательством РК; отметка, подтверждающая нотариальное удостоверение такой сделки, если нотариальное удостоверение требуется в соответствии с законодательством или соглашением сторон)" });
                cs.Add(new DicClassificationSubtitle { Code = "56", DocClassificationId = dguid, ParagraphNumber = 2, NameKk = "Документ, подтверждающий выполнение определенных условий сделки, в силу чего у Залогодателя возникает право требования (к примеру, акт выполненных работ или акт приема-передачи) (при наличии)", NameRu = "Документ, подтверждающий выполнение определенных условий сделки, в силу чего у Залогодателя возникает право требования (к примеру, акт выполненных работ или акт приема-передачи) (при наличии)" });
            }


            foreach (DicClassificationSubtitle c in cs)
            {
                if (!context.DicClassificationSubtitles.Where(x => x.Code.Equals(c.Code)).Any())
                {
                    context.DicClassificationSubtitles.Add(c);
                }
            }

            #endregion
            context.SaveChanges();

            #region DicClassificationSubtitle

            List<DicWarningClassification> ws = new List<DicWarningClassification>();

            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("1")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("1")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("2")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("2")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документа требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документа требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в том числе, отсутствие электронной цифровой подписи(если свидетельство о государственной регистрации ИП выдано в форме электронного документа)", NameRu = "Отсутствие на документах необходимых подписей и печатей, в том числе, отсутствие электронной цифровой подписи(если свидетельство о государственной регистрации ИП выдано в форме электронного документа)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("3")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("3")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фамилии и (или) имени и (или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения (если невозможно идентифицировать по ИИН).", NameRu = "Несоответствие фамилии и (или) имени и (или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения (если невозможно идентифицировать по ИИН)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фамилии, указанной в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения (если возможно идентифицировать по ИИН).", NameRu = "Несоответствие фамилии, указанной в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения (если возможно идентифицировать по ИИН)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("4")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("4")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: -для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных).", NameRu = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: -для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета.", NameRu = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия.", NameRu = "Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("5")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("5")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("6")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("6")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в том числе, отсутствие электронной цифровой подписи (если свидетельство о государственной регистрации КХ выдано в форме электронного документа)", NameRu = "Отсутствие на документах необходимых подписей и печатей, в том числе, отсутствие электронной цифровой подписи (если свидетельство о государственной регистрации КХ выдано в форме электронного документа)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("7")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("7")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("8")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("8")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документа требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документа требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей(проверяет уполномоченный государственный орган).", NameRu = "Отсутствие на документах необходимых подписей и печатей(проверяет уполномоченный государственный орган)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("9")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("9")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: -для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных).", NameRu = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: -для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета. 5.Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия.", NameRu = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета. 5.Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фамилии и(или) имени и(или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака(при наличии). В случае изменения фамилии и(или) имени и(или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения.", NameRu = "Несоответствие фамилии и(или) имени и(или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака(при наличии). В случае изменения фамилии и(или) имени и(или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("10")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("10")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: - для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики (площадь); - для движимого имущества – наименование, модель/марка, серийный номер, цвет (при наличии), государственный регистрационный номер (при наличии), количество/стоимость (для товаров в обороте); наименование, и идентификационные характеристики (для сельскохозяйственных животных).", NameRu = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: - для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики (площадь); - для движимого имущества – наименование, модель/марка, серийный номер, цвет (при наличии), государственный регистрационный номер (при наличии), количество/стоимость (для товаров в обороте); наименование, и идентификационные характеристики (для сельскохозяйственных животных)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и (или) права на безакцептное списание денег со счета.", NameRu = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и (или) права на безакцептное списание денег со счета." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах информации о должниках (должнике), по обязательствам которых (которого) имущество предоставляется в залог или предоставляется гарантия.", NameRu = "Отсутствие в документах информации о должниках (должнике), по обязательствам которых (которого) имущество предоставляется в залог или предоставляется гарантия." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие записи нотариального удостоверения подписей.", NameRu = "Отсутствие записи нотариального удостоверения подписей." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("11")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("11")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность", NameRu = "Истечение срока действия документа, удостоверяющего личность" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("12")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("12")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фамилии и (или) имени и (или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения.", NameRu = "Несоответствие фамилии и (или) имени и (или) отчества, указанного в документе, удостоверяющем личность, с информацией, указанной в свидетельстве о заключении брака (при наличии). В случае изменения фамилии и (или) имени и (или) отчества по иным основаниям должен быть предоставлен документ, подтверждающий данные изменения." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Истечение срока действия документа, удостоверяющего личность супруги / супруга.", NameRu = "Истечение срока действия документа, удостоверяющего личность супруги / супруга." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("13")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("13")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("14")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("14")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах данных недвижимого имущества.", NameRu = "Отсутствие на документах данных недвижимого имущества." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и (или) права на безакцептное списание денег со счета.", NameRu = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и (или) права на безакцептное списание денег со счета." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("15")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("15")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: - для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных).", NameRu = "Отсутствие в документах описания имущества, предлагаемого в залог, и его идентификационных характеристик: - для недвижимого имущества – наименование, адрес, кадастровый номер, технические характеристики(площадь); -для движимого имущества – наименование, модель / марка, серийный номер, цвет (при наличии), государственный регистрационный номер(при наличии), количество / стоимость(для товаров в обороте); наименование, и идентификационные характеристики(для сельскохозяйственных животных)." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета. 5.Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия.", NameRu = "Отсутствие в документах права Общества на внесудебную реализацию передаваемого в залог имущества и(или) права на безакцептное списание денег со счета. 5.Отсутствие в документах информации о должниках(должнике), по обязательствам которых(которого) имущество предоставляется в залог или предоставляется гарантия." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("16")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("16")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу(если срок исковой давности не истек).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу(если срок исковой давности не истек)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие акта приемки легализованного объекта недвижимого имущества в эксплуатацию при легализации имущества.", NameRu = "Отсутствие акта приемки легализованного объекта недвижимого имущества в эксплуатацию при легализации имущества." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие штампов либо уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на недвижимое имущество, на правоустанавливающих документах.", NameRu = "Отсутствие штампов либо уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на недвижимое имущество, на правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие информации, указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих и(или) технических документах.", NameRu = "Несоответствие информации, указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих и(или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в правоустанавливающем документе индивидуально - определенных признаков(адрес и(или) технические характеристики(площадь)) имущества(Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально - определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года(дата утверждения Правил по проведению технической инвентаризации(технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним).", NameRu = "Отсутствие в правоустанавливающем документе индивидуально - определенных признаков(адрес и(или) технические характеристики(площадь)) имущества(Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально - определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года(дата утверждения Правил по проведению технической инвентаризации(технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и(или) технических документах.", NameRu = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и(или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек)." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в правоустанавливающем документе индивидуально - определенных признаков(адрес и(или) технические характеристики(площадь)) имущества. (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально - определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года(дата утверждения Правил по проведению технической инвентаризации(технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним).", NameRu = "Отсутствие в правоустанавливающем документе индивидуально - определенных признаков(адрес и(или) технические характеристики(площадь)) имущества. (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально - определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года(дата утверждения Правил по проведению технической инвентаризации(технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним)." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и(или) технических документах(если идентификация возможна по другим техническим и идентификационным данным). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений(адреса) или при изменении кадастровых номеров в связи с реформированием административно - территориального устройства Республики Казахстан, и осуществляется безвозмездно).", NameRu = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и(или) технических документах(если идентификация возможна по другим техническим и идентификационным данным). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений(адреса) или при изменении кадастровых номеров в связи с реформированием административно - территориального устройства Республики Казахстан, и осуществляется безвозмездно)." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Площадь балкона/лоджии не включена в общую площадь недвижимого имущества (общая площадь жилища - сумма полезной площади жилища и площадей балконов (лоджий, веранд, террас), рассчитываемых с применением понижающих коэффициентов в соответствии с нормативно-техническими актами п.п. 33 статьи 2 ЗРК «О жилищных отношениях»).", NameRu = "Площадь балкона/лоджии не включена в общую площадь недвижимого имущества (общая площадь жилища - сумма полезной площади жилища и площадей балконов (лоджий, веранд, террас), рассчитываемых с применением понижающих коэффициентов в соответствии с нормативно-техническими актами п.п. 33 статьи 2 ЗРК «О жилищных отношениях»)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("17")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("17")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в технических паспортах на недвижимое имущество сведений, необходимых для идентификации предмета залога (адрес объекта недвижимости, площади, кадастровый номер).", NameRu = "Отсутствие в технических паспортах на недвижимое имущество сведений, необходимых для идентификации предмета залога (адрес объекта недвижимости, площади, кадастровый номер)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в техническом паспорте / плане подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в техническом паспорте / плане подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и(или) техническими документами.", NameRu = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и(или) техническими документами." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие неузаконенной перепланировки(реконструкции) предмета залога, связанной с изменением конструкций: -снесен дверной проем / окно балкона, лоджии; -снесена несущая стена; -изготовлен дверной / оконный проем в несущей стене; -изменение сантехнических узлов(перечень изменений не исчерпывающий)", NameRu = "Наличие неузаконенной перепланировки(реконструкции) предмета залога, связанной с изменением конструкций: -снесен дверной проем / окно балкона, лоджии; -снесена несущая стена; -изготовлен дверной / оконный проем в несущей стене; -изменение сантехнических узлов(перечень изменений не исчерпывающий)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Наличие неузаконенной перепланировки (реконструкции) предмета залога, связанной с изменением конструкций: - изменение дверного проема на оконный; -снесена стена не несущей конструкции; -установление дополнительных перегородок; -замена дверного проема на арку(перечень изменений не исчерпывающий)", NameRu = "Наличие неузаконенной перепланировки (реконструкции) предмета залога, связанной с изменением конструкций: - изменение дверного проема на оконный; -снесена стена не несущей конструкции; -установление дополнительных перегородок; -замена дверного проема на арку(перечень изменений не исчерпывающий)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("18")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("18")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000 - кратный размер МРП(если сделка заключена между двумя юридическими лицами).", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000 - кратный размер МРП(если сделка заключена между двумя юридическими лицами)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("19")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("19")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа).", NameRu = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и(или) технических документах.", NameRu = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и(или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в справке индивидуально - определенных признаков имущества(адрес, технические характеристики(площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество.", NameRu = "Отсутствие в справке индивидуально - определенных признаков имущества(адрес, технические характеристики(площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний.", NameRu = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("20")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("20")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности не истек).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности не истек)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие штампов или уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на земельный участок, на правоустанавливающих документах.", NameRu = "Отсутствие штампов или уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на земельный участок, на правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие штампов уполномоченных регистрирующих органов на правоустанавливающих документах, удостоверяющих регистрацию изменений, в случае изменений сведений о правообладателе и идентификационных характеристик объекта недвижимости.", NameRu = "Отсутствие штампов уполномоченных регистрирующих органов на правоустанавливающих документах, удостоверяющих регистрацию изменений, в случае изменений сведений о правообладателе и идентификационных характеристик объекта недвижимости." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие информации (адрес, кадастровый номер), указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих документах.", NameRu = "Несоответствие информации (адрес, кадастровый номер), указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) технических характеристик (площадь) и (или) кадастровый номер) земельного участка.", NameRu = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) технических характеристик (площадь) и (или) кадастровый номер) земельного участка." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фактического адреса земельного участка адресу, указанному в правоустанавливающих и (или) идентификационных документах.", NameRu = "Несоответствие фактического адреса земельного участка адресу, указанному в правоустанавливающих и (или) идентификационных документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Срок права землепользования (аренды) на земельный участок, предлагаемого в качестве залогового обеспечения, меньше срока займа.", NameRu = "Срок права землепользования (аренды) на земельный участок, предлагаемого в качестве залогового обеспечения, меньше срока займа." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Право землепользования на земельный участок является краткосрочным (до 5 лет).", NameRu = "Право землепользования на земельный участок является краткосрочным (до 5 лет)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Право землепользования на земельный участок с целевым назначением для ведения крестьянского или фермерского хозяйства предоставлено юридическому лицу.", NameRu = "Право землепользования на земельный участок с целевым назначением для ведения крестьянского или фермерского хозяйства предоставлено юридическому лицу." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие нотариально удостоверенного письменного согласия участников общей собственности или общего землепользования на залог неделимого земельного участка, находящегося в общей совместной собственности или землепользовании. (Заключение договора дарения от имени несовершеннолетних лиц их законными представителями (такие сделки в соответствии со ст.509 Гражданского кодекса РК не допускаются). (Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются).", NameRu = "Отсутствие нотариально удостоверенного письменного согласия участников общей собственности или общего землепользования на залог неделимого земельного участка, находящегося в общей совместной собственности или землепользовании. (Заключение договора дарения от имени несовершеннолетних лиц их законными представителями (такие сделки в соответствии со ст.509 Гражданского кодекса РК не допускаются). (Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются)." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("21")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("21")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка.", NameRu = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождений между правоустанавливающими и идентификационными документами.", NameRu = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождений между правоустанавливающими и идентификационными документами." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь).", NameRu = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка)", NameRu = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("22")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("22")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("23")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("23")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа).", NameRu = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и(или) идентификационных документах.", NameRu = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и(или) идентификационных документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в справке индивидуально - определенных признаков имущества(адрес, кадастровый номер, технические характеристики(площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество, предлагаемое в залог.", NameRu = "Отсутствие в справке индивидуально - определенных признаков имущества(адрес, кадастровый номер, технические характеристики(площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество, предлагаемое в залог." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний.", NameRu = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("24")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("24")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности не истек).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности не истек)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие акта приемки легализованного объекта недвижимого имущества в эксплуатацию при легализации имущества.", NameRu = "Отсутствие акта приемки легализованного объекта недвижимого имущества в эксплуатацию при легализации имущества." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие штампов или уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на земельный участок, на правоустанавливающих документах.", NameRu = "Отсутствие штампов или уведомлений уполномоченных регистрирующих органов, удостоверяющих регистрацию права на земельный участок, на правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие штампов уполномоченных регистрирующих органов на правоустанавливающих документах, удостоверяющих регистрацию изменений, в случае изменений сведений о правообладателе и идентификационных характеристик объекта недвижимости.", NameRu = "Отсутствие штампов уполномоченных регистрирующих органов на правоустанавливающих документах, удостоверяющих регистрацию изменений, в случае изменений сведений о правообладателе и идентификационных характеристик объекта недвижимости." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие информации (адрес, кадастровый номер), указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих документах.", NameRu = "Несоответствие информации (адрес, кадастровый номер), указанной в штампе уполномоченного регистрирующего органа, информации, указанной в правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) площадь, и (или) кадастровый номер (для земельных участков)) имущества. Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним.", NameRu = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) площадь, и (или) кадастровый номер (для земельных участков)) имущества. Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и (или) идентификационных и (или) технических документах.", NameRu = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и (или) идентификационных и (или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие целевого назначения зданий (строений), находящихся на земельном участке, целевому назначению земельного участка, в случаях, когда категория здания (строения) не совпадает с категорией земельного участка 12. Срок права землепользования (аренды) на земельный участок меньше срока займа.", NameRu = "Несоответствие целевого назначения зданий (строений), находящихся на земельном участке, целевому назначению земельного участка, в случаях, когда категория здания (строения) не совпадает с категорией земельного участка 12. Срок права землепользования (аренды) на земельный участок меньше срока займа." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Право землепользования на земельный участок является краткосрочным (до 5 лет).", NameRu = "Право землепользования на земельный участок является краткосрочным (до 5 лет)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие нотариально удостоверенного письменного согласия участников общей собственности или общего землепользования на залог неделимого земельного участка, находящегося в общей совместной собственности или землепользовании.", NameRu = "Отсутствие нотариально удостоверенного письменного согласия участников общей собственности или общего землепользования на залог неделимого земельного участка, находящегося в общей совместной собственности или землепользовании." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие согласия уполномоченного органа на совершение сделки с имуществом субъекта естественной монополии, в соответствии с требованиями п. 1 ст. 18-1 ЗРК «О естественных монополиях и регулируемых рынках» (Заключение договора дарения от имени несовершеннолетних лиц их законными представителями (такие сделки в соответствии со ст.509 Гражданского кодекса РК не допускаются. Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются).", NameRu = "Отсутствие согласия уполномоченного органа на совершение сделки с имуществом субъекта естественной монополии, в соответствии с требованиями п. 1 ст. 18-1 ЗРК «О естественных монополиях и регулируемых рынках» (Заключение договора дарения от имени несовершеннолетних лиц их законными представителями (такие сделки в соответствии со ст.509 Гражданского кодекса РК не допускаются. Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются)." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек). Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) технические характеристики (площадь)) имущества. (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек). Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (адрес и (или) технические характеристики (площадь)) имущества. (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним)." });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и (или) технических документах (если идентификация возможна по другим техническим и идентификационным данным). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений (адреса) или при изменении кадастровых номеров в связи с реформированием административно-территориального устройства Республики Казахстан, и осуществляется безвозмездно).", NameRu = "Несоответствие фактического адреса объекта адресу, указанному в правоустанавливающих и (или) технических документах (если идентификация возможна по другим техническим и идентификационным данным). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений (адреса) или при изменении кадастровых номеров в связи с реформированием административно-территориального устройства Республики Казахстан, и осуществляется безвозмездно)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("25")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("25")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка.", NameRu = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и идентификационными документами.", NameRu = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и идентификационными документами." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь).", NameRu = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка).", NameRu = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("26")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("26")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000 - кратный размер МРП(если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000 - кратный размер МРП(если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("27")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("27")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в технических паспортах на недвижимое имущество сведений, необходимых для идентификации предмета залога (адрес объекта недвижимости, кадастровый номер).", NameRu = "Отсутствие в технических паспортах на недвижимое имущество сведений, необходимых для идентификации предмета залога (адрес объекта недвижимости, кадастровый номер)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и (или) идентификационными и (или) техническими документами.", NameRu = "Отсутствие документов, подтверждающих изменение идентификационных характеристик предмета залога, в случае наличия расхождения между правоустанавливающими и (или) идентификационными и (или) техническими документами." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие правоустанавливающих документов на объекты недвижимости, находящиеся на земельном участке и указанные в техническом паспорте.", NameRu = "Отсутствие правоустанавливающих документов на объекты недвижимости, находящиеся на земельном участке и указанные в техническом паспорте." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие неузаконенной перепланировки (реконструкции) предмета залога, связанной с изменением несущих и ограждающих конструкций.", NameRu = "Наличие неузаконенной перепланировки (реконструкции) предмета залога, связанной с изменением несущих и ограждающих конструкций." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие (в случае превышения) фактически занимаемой площади земельного участка, отраженной в экспликации земельного участка технического паспорта, площади земельного участка, отраженной в правоустанавливающих и идентификационных документах на земельный участок (в случае, если на превышающей части земельного участка расположены объекты недвижимости, предлагаемые в залог)", NameRu = "Несоответствие (в случае превышения) фактически занимаемой площади земельного участка, отраженной в экспликации земельного участка технического паспорта, площади земельного участка, отраженной в правоустанавливающих и идентификационных документах на земельный участок (в случае, если на превышающей части земельного участка расположены объекты недвижимости, предлагаемые в залог)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Использование предмета залога не в соответствии с его целевым назначением, в случае, если предметом залога является жилое помещение с самостоятельным земельным участком (пристроенные помещения, расположенные на первых этажах многоэтажных жилых домов, имеющие отдельную входную группу), которое используется в качестве нежилого (коммерческого) помещения.", NameRu = "Использование предмета залога не в соответствии с его целевым назначением, в случае, если предметом залога является жилое помещение с самостоятельным земельным участком (пристроенные помещения, расположенные на первых этажах многоэтажных жилых домов, имеющие отдельную входную группу), которое используется в качестве нежилого (коммерческого) помещения." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в техническом паспорте (плане) подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в техническом паспорте (плане) подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("28")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("28")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа).", NameRu = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) идентификационных и (или) технических документах.", NameRu = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) идентификационных и (или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в справке индивидуально-определенных признаков имущества (адрес, кадастровый номер, технические характеристики (площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество, предлагаемое в залог.", NameRu = "Отсутствие в справке индивидуально-определенных признаков имущества (адрес, кадастровый номер, технические характеристики (площадь)), сведений о правообладателе и о правоустанавливающих документах на имущество, предлагаемое в залог." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний.", NameRu = "Наличие в справке информации о зарегистрированных юридических притязаниях третьих лиц в случае, если истек срок исковой давности с момента регистрации зарегистрированных юридических притязаний." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("29")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("29")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("30")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("30")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек). (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений (адреса) или при изменении кадастровых номеров в связи с реформированием административно-территориального устройства Республики Казахстан, и осуществляется безвозмездно).", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу (если срок исковой давности истек). (Предоставление документов, подтверждающих приобретение предмета залога, в которых отсутствуют индивидуально-определенные признаки имущества, допускается, если такие документы датированы ранее 14 декабря 1999 года (дата утверждения Правил по проведению технической инвентаризации (технического обследования) недвижимости для государственной регистрации прав на недвижимое имущество и сделок с ним). (В тех случаях, когда изменение идентификационных характеристик происходит по решению государственных органов, регистрация не может быть возложена на правообладателя, в том числе при изменении наименования населенных пунктов, названия улиц, а также порядкового номера зданий и иных строений (адреса) или при изменении кадастровых номеров в связи с реформированием административно-территориального устройства Республики Казахстан, и осуществляется безвозмездно)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("31")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("31")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка/права землепользования.", NameRu = "Наличие ограничений в использовании и обременения земельного участка, отраженные в соответствующей графе идентификационного документа и запрещающие совершение сделок в отношении данного земельного участка/права землепользования." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь).", NameRu = "Отсутствие в идентификационном документе на земельный участок сведений, необходимых для идентификации предмета залога (адрес, кадастровый номер, площадь)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в идентификационном документе на земельный участок подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка)", NameRu = "Отсутствие сведений о переходе прав на земельный участок из земельно-кадастровой книги и единого государственного реестра земель (при переходе прав на земельный участок в случае отсутствия изменений идентификационных характеристик земельного участка)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("32")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("32")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("33")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("33")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа).", NameRu = "Наличие в справке информации о зарегистрированных обременениях (арестах), юридических притязаний третьих лиц (за исключением наличия зарегистрированного залога при рефинансировании займа)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) идентификационных документах.", NameRu = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) идентификационных документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в справке индивидуально-определенных признаков имущества (адрес, кадастровый номер, технические характеристики (площадь)), сведений о правообладателе и о правоустанавливающих документах на земельный участок.", NameRu = "Отсутствие в справке индивидуально-определенных признаков имущества (адрес, кадастровый номер, технические характеристики (площадь)), сведений о правообладателе и о правоустанавливающих документах на земельный участок." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("34")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("34")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("35")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("35")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "3", ClassificationSubtitleId = cguid, NameKk = "Отсутствие правоустанавливающего документа.", NameRu = "Отсутствие правоустанавливающего документа." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("36")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("36")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие правоустанавливающего документа.", NameRu = "Отсутствие правоустанавливающего документа." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в технических документах, данным, указанным в правоустанавливающих документах.", NameRu = "Несоответствие данных, указанных в технических документах, данным, указанным в правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("37")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("37")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("38")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("38")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в декларации, данным, указанным в правоустанавливающих документах.", NameRu = "Несоответствие данных, указанных в декларации, данным, указанным в правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("39")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("39")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в справке информации о зарегистрированных обременениях (арестах) третьих лиц.", NameRu = "Наличие в справке информации о зарегистрированных обременениях (арестах) третьих лиц." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) технических документах.", NameRu = "Несоответствие данных, указанных в справке, данным, указанным в правоустанавливающих и (или) технических документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("40")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("40")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("41")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("41")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("42")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("42")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("43")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("43")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу.", NameRu = "Отсутствие на решении суда о признании права собственности отметки о вступлении в законную силу." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются).", NameRu = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (наименование, количество, стоимость).", NameRu = "Отсутствие в правоустанавливающем документе индивидуально-определенных признаков (наименование, количество, стоимость)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("44")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("44")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("45")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("45")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в декларации, данным, указанным в правоустанавливающих документах ", NameRu = "Несоответствие данных, указанных в декларации, данным, указанным в правоустанавливающих документах " });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("46")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("46")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются).", NameRu = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в договоре подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в договоре подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("47")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("47")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на счете суммы денег, необходимой для принятия в залог", NameRu = "Отсутствие на счете суммы денег, необходимой для принятия в залог" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("48")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("48")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются).", NameRu = "Заключение сделки представителем по доверенности от имени представляемого в отношении себя лично, или в отношении другого лица, представителем которого он одновременно является (такие сделки в соответствии со ст.167 Гражданского кодекса РК не допускаются)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в договоре подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в договоре подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("49")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("49")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("50")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("50")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("51")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("51")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("52")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("52")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие в документах индивидуально-определенных признаков (при наличии).", NameRu = "Отсутствие в документах индивидуально-определенных признаков (при наличии)." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("53")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("53")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие данных, указанных в технических документах, данным, указанным в правоустанавливающих документах.", NameRu = "Несоответствие данных, указанных в технических документах, данным, указанным в правоустанавливающих документах." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("54")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("54")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)", NameRu = "Предоставление платежных документов, подтверждающих оплату наличным путем, по сделкам, сумма которых превышает 1000-кратный размер МРП (если сделка заключена между двумя юридическими лицами)" });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("55")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("55")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК.", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений.", NameRu = "Наличие в правоустанавливающих документах подчисток либо приписок, зачеркнутых слов или иных неоговоренных исправлений." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }
            if (context.DicClassificationSubtitles.Where(x => x.Code.Equals("56")).Any())
            {
                Guid cguid = context.DicClassificationSubtitles.Where(x => x.Code.Equals("56")).FirstOrDefault().Id;
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК.", NameRu = "Отсутствие на документах необходимых подписей и печатей, в случаях, предусмотренных законодательством РК." });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК. ", NameRu = "Несоответствие формы и содержания документов требованиям, установленным законодательством РК. " });
                ws.Add(new DicWarningClassification { Code = "1", ClassificationSubtitleId = cguid, NameKk = "Иное (1 категория)", NameRu = "Иное (1 категория)" });
                ws.Add(new DicWarningClassification { Code = "2", ClassificationSubtitleId = cguid, NameKk = "Иное (2,3 категория)", NameRu = "Иное (2,3 категория)" });
            }

            foreach (DicWarningClassification w in ws)
            {
                if (!context.DicWarningClassifications.Where(x => x.ClassificationSubtitleId.Equals(w.ClassificationSubtitleId) && x.NameRu.Equals(w.NameRu)).Any())
                {
                    context.DicWarningClassifications.Add(w);
                }
            }



            context.SaveChanges();

            #endregion
        }
        public static void SeedDecision(DataContext context)
        {
            DicDecision[] decisions =
                {
                    new DicDecision(){Code="accept", NameKk="", NameRu="одобрено" },
                    new DicDecision(){Code="success", NameKk="", NameRu="успешно" },
                    new DicDecision(){Code="reject", NameKk="", NameRu="отказано" },
                    new DicDecision(){Code="return", NameKk="", NameRu="возвращено" }
                };
            foreach (DicDecision val in decisions)
            {
                if (!context.DicDecisions.Where(x => x.Code.Equals(val.Code)).Any())
                {
                    context.DicDecisions.Add(val);
                }
            }

            context.SaveChanges();
        }
    }
}