using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class BrandsStores
    {
        private readonly IGetAllBrandsQuary _getAllBrandsQuary;
        private readonly ICreateBrandCommand _createBrandCommand;
        private readonly IUpdateBrandCommand _updateBrandCommand;
        private readonly IDeleteBrandCommand _deleteBrandCommand;
        private readonly List<BrandModel> _brandModels;

        public IEnumerable<BrandModel> brandModels => _brandModels;

        public BrandsStores(IGetAllBrandsQuary getAllBrandsQuary,
            ICreateBrandCommand createBrandCommand,
            IUpdateBrandCommand updateBrandCommand,
            IDeleteBrandCommand deleteBrandCommand)
        {
            _getAllBrandsQuary = getAllBrandsQuary;
            _createBrandCommand = createBrandCommand;
            _updateBrandCommand = updateBrandCommand;
            _deleteBrandCommand = deleteBrandCommand;

            _brandModels = new List<BrandModel>();
        }

        public event Action BrandLoaded;
        public event Action<BrandModel> BrandAdded;
        public event Action<BrandModel> BrandEdited;
        public event Action<Guid> BrandDeleted;
        public async Task Load()
        {
            IEnumerable<BrandModel> brands = await _getAllBrandsQuary.Execute();

            _brandModels.Clear();
            _brandModels.AddRange(brands);

            BrandLoaded?.Invoke();
        }
        public async Task Add(BrandModel brandModel)
        {
            await _createBrandCommand.Execute(brandModel);

            _brandModels.Add(brandModel);

            BrandAdded?.Invoke(brandModel);
        }
        public async Task Update(BrandModel brandModel)
        {
            await _updateBrandCommand.Execute(brandModel);

            int currentIndex = _brandModels.FindIndex(b => b.Id == brandModel.Id);

            if (currentIndex != -1)
            {
                _brandModels[currentIndex] = brandModel;
            }
            else
            {
                _brandModels.Add(brandModel);
            }
            BrandEdited?.Invoke(brandModel);
        }

        public async Task Delete(Guid BrandId)
        {
            await _deleteBrandCommand.Execute(BrandId);

            BrandDeleted?.Invoke(BrandId);

            _brandModels.RemoveAll(y => y.Id == BrandId);
        }
    }
}
