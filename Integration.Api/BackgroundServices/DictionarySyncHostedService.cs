using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Agro.Integration.Logic.OutService.C1Service;
using Agro.Shared.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Agro.Integration.Api.BackgroundServices
{
    public class DictionarySyncHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly IDictionarySyncLogic _dictSyncLogic;
        private readonly IOptions<AppSettings> _options;

        private Timer _timer;

        public DictionarySyncHostedService(IDictionarySyncLogic logic, IOptions<AppSettings> options)
        {
            _dictSyncLogic = logic;
            _options = options;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void DoWork(object state)
        {
            //await _dictSyncLogic.SyncCountries(await _dictSyncLogic.GetJsonAsync("Catalog_КлассификаторСтранМира"));
            //await _dictSyncLogic.SyncClientTypes(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ОрганизационноПравовыеФормы"));
            //await _dictSyncLogic.SyncPledgeTypes(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ВидыОбеспечения"));
            //await _dictSyncLogic.SyncLandPurposes(await _dictSyncLogic.GetJsonAsync("Catalog_КатегорииЗемель"));

            
            //await _dictSyncLogic.SyncFirstDocTypes(await _dictSyncLogic.GetJsonAsync("ChartOfCharacteristicTypes_ДО_ВидыДокументов", "Parent_Key eq guid'f4e3636a-eb62-11e4-b56d-000c29b639a8'"));

            //await _dictSyncLogic.SyncFileTypes(await _dictSyncLogic.GetJsonAsync("ChartOfCharacteristicTypes_ДО_ВидыДокументов", "Parent_Key eq guid'fe9d41aa-eb62-11e4-b56d-000c29b639a8'"));

            //await _dictSyncLogic.SyncKATO(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_АдресныйКлассификатор"));
            //await _dictSyncLogic.SyncAuthorizedOrgans(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_УполномоченныеОрганы"));
            //await _dictSyncLogic.SyncAffilationTypes(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_СвязьСБВУиНО"));
            //await _dictSyncLogic.SyncBanks(await _dictSyncLogic.GetJsonAsync("Catalog_Банки"));
            // await _dictSyncLogic.SyncBorrowerCategory(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_КатегорииЗаемщиков"));
            // await _dictSyncLogic.SyncCertTypes(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ВидыСертификатов"));
            // await _dictSyncLogic.SyncCreditProgram(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ПрограммыКредитования"));
            // await _dictSyncLogic.SyncEnsuringTypes(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ВидыОбеспечения"));
            //await _dictSyncLogic.SyncFinancingSources(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ИсточникиФинансирования"));
            //await _dictSyncLogic.SyncIdDocTypes(await _dictSyncLogic.GetJsonAsync("Catalog_ДокументыУдостоверяющиеЛичность"));
            // await _dictSyncLogic.SyncLandCategories(await _dictSyncLogic.GetJsonAsync("Catalog_КатегорииЗемель"));
            // await _dictSyncLogic.SyncMetricTypes(await _dictSyncLogic.GetJsonAsync("Catalog_КлассификаторЕдиницИзмерения"));
            // await _dictSyncLogic.SyncOKED(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_КлассификаторВидовЭкономическойДеятельности"));
            // await _dictSyncLogic.SyncOPF(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ОрганизационноПравовыеФормы"));
            //await _dictSyncLogic.SyncOrganizations(await _dictSyncLogic.GetJsonAsync("Catalog_Организации"));
            // await _dictSyncLogic.SyncPenalties(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ВидыПени"));
            //await _dictSyncLogic.SyncSpecialPurpose(await _dictSyncLogic.GetJsonAsync("Catalog_Кредиты_ЦелевыеНазначения"));
            //_logger.LogInformation("DictionarySyncHostedService is working. Count: {Count}", count);
        }



        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("DictionarySyncHostedService running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10000));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("DictionarySyncHostedService is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}