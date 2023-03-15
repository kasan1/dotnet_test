using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Agro.Integration.Logic.Models.C1;
using Agro.Shared.Data;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Repos;
using Agro.Shared.Data.Repos.Dictionary;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Agro.Integration.Logic.OutService.C1Service
{
    public class DictionarySyncLogic : IDictionarySyncLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOptions<AppSettings> _options;

        public DictionarySyncLogic(IOptions<AppSettings> options, IUnitOfWork unitOfWork)
        {
            _options = options;
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> GetJsonAsync(string dictionaryNameRu)
        {
            var url = $"{_options.Value.C1IntegrationOptions.Url}/{dictionaryNameRu}?";
            var prms = new NameValueCollection() {
                {"$select", "*"},
                {"$filter", "DeletionMark eq false "},
                {"$format", "json;odata=nometadata" }
            };
            url = url + string.Join("&",
                prms.AllKeys.Select(key => $"{key}={prms.GetValues(key).FirstOrDefault()}").ToArray());
            byte[] _ = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_options.Value.C1IntegrationOptions.Url);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{_options.Value.C1IntegrationOptions.Login}:{_options.Value.C1IntegrationOptions.Password}")}");
                _ = await httpClient.GetByteArrayAsync(Uri.EscapeUriString(url));
            }
            return _;
        }


        public async Task<byte[]> GetJsonAsync(string dictionaryNameRu, string filter)
        {
            var url = $"{_options.Value.C1IntegrationOptions.Url}/{dictionaryNameRu}?";
            var prms = new NameValueCollection() {
                {"$select", "*"},
                {"$filter", filter},
                {"$format", "json;odata=nometadata" }
            };
            url = url + string.Join("&",
                prms.AllKeys.Select(key => $"{key}={prms.GetValues(key).FirstOrDefault()}").ToArray());
            byte[] _ = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_options.Value.C1IntegrationOptions.Url);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {EncoderHelper.Base64Encode($"{_options.Value.C1IntegrationOptions.Login}:{_options.Value.C1IntegrationOptions.Password}")}");
                _ = await httpClient.GetByteArrayAsync(Uri.EscapeUriString(url));
            }
            return _;
        }

        public async Task SyncAffilationTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cAffilationTypeDto>>(json);
            _ = items;

            throw new NotImplementedException();
        }

        public async Task SyncClientTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cClientTypeDto>>(json);
            var repo = new DictionaryRepo<DicClientType>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicClientType()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public async Task SyncPledgeTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cPledgeTypeDto>>(json);
            var repo = new DictionaryRepo<DicPledgeType>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicPledgeType()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk =  item.NameKz,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public async Task SyncLandPurposes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cLandPurposeDto>>(json);
            var repo = new DictionaryRepo<DicLandPurpose>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicLandPurpose()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk = item.NameRu,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public async Task SyncFirstDocTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cFirstDocTypeDto>>(json);
            var repo = new DictionaryRepo<DicFirstDocType>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicFirstDocType()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk = string.IsNullOrWhiteSpace(item.NameKz) ? item.Description : item.NameKz,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public async Task SyncFileTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cFileTypeDto>>(json);
            var repo = new DictionaryRepo<DicFileType>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicFileType()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk = string.IsNullOrWhiteSpace(item.NameKz) ? item.Description : item.NameKz,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }




        public Task SyncAuthorizedOrgans(byte[] bytes)
        {
            throw new NotImplementedException();
        }


        public Task SyncBorrowerCategory(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncCertTypes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public async Task SyncCountries(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cCountryDto>>(json);
            var repo = new DictionaryRepo<DicCountry>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicCountry()
                {
                    Id = item.Id,
                    NameRu = string.IsNullOrWhiteSpace(item.NameRu) ? item.Description : item.NameRu,
                    NameKk = item.Description,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public Task SyncCreditProgram(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncEnsuringTypes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public async Task SyncIdDocTypes(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cIdDocTypeDto>>(json);
            var repo = new DictionaryRepo<DicDocumentType>(_unitOfWork.GetContext());
            foreach (var item in items.value)
            {
                var itemFromDb = await repo.GetById(item.Id);
                var itemEntity = new DicDocumentType()
                {
                    Id = item.Id,
                    NameRu = item.Description,
                    NameKk = string.IsNullOrWhiteSpace(item.NameKz) ? item.Description : item.NameKz,
                    Code = item.Code,
                    IsDeleted = item.DeletionMark
                };
                if (itemFromDb == null)
                {
                    await repo.Add(itemEntity);
                }
                else
                {
                    if (item.DeletionMark != itemFromDb.IsDeleted)
                        await repo.Update(itemEntity);
                }
            }
        }

        public Task SyncLandCategories(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncMetricTypes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncOKED(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncOPF(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public Task SyncOrganizations(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);
            var items = JsonConvert.DeserializeObject<Dic1cJsonDto<Dic1cOrganizationDto>>(json);
            //var repo = new DictionaryRepo<DicCountry>(_unitOfWork.GetContext());

            Action<Dic1cOrganizationDto> process1cOrgDto = dto =>
            {
                if (!string.IsNullOrWhiteSpace(dto.CodeOCA))
                {
                    var itemFromDb = _unitOfWork.BranchRepository.GetQueryable(x => x.CodeOCA == dto.CodeOCA.Trim(' ')).FirstOrDefault();
                    var itemEntity = new Branch()
                    {
                        Id = dto.Id,
                        NameKz = dto.Description,
                        NameRu = dto.Description,
                        // AddressKz = dto.AddressKz,
                        // AddressRu = dto.AddressRu,
                        Bin = dto.Bin,
                        //CodeGBDFL = dto.CodeGBDFL,
                        CodeKato = dto.CodeKato,
                        CodeOCA = dto.CodeOCA,
                        ParentId = (dto.ParentId == new Guid() || dto.ParentId == dto.Id) ? null : dto.ParentId,
                        // Phone = dto.Phone,
                        // Code = dto.Code,
                        IsDeleted = dto.DeletionMark
                    };
                    if (itemFromDb == null)
                    {
                        _unitOfWork.BranchRepository.Add(itemEntity).GetAwaiter().GetResult();
                    }
                    else
                    {
                        itemFromDb.Bin = dto.Bin;
                        //itemFromDb.CodeGBDFL = dto.CodeGBDFL;
                        // itemFromDb.Code = dto.Code;
                        _unitOfWork.BranchRepository.Update(itemFromDb).GetAwaiter().GetResult();
                    }
                }

            };

            foreach (var item in items.value.Where(x => x.ParentId == new Guid() || x.ParentId == x.Id))
            {
                process1cOrgDto(item);
                foreach (var childItem in items.value.Where(x => x.ParentId == item.Id))
                {
                    process1cOrgDto(childItem);
                    foreach (var grandChildItem in items.value.Where(x => x.ParentId == childItem.Id))
                    {
                        process1cOrgDto(grandChildItem);
                    }
                }
            }
            return Task.CompletedTask;
        }

        public Task SyncPenalties(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}