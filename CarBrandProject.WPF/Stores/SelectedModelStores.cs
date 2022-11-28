using CarBrandProject.WPF.Models;
using System;

namespace CarBrandProject.WPF.Stores
{
    public class SelectedModelStores
    {
        private readonly ModelsStore _modelsStore;

        private ModelsModel _modelStore;
        public ModelsModel ModelStore
        {
            get { return _modelStore; }
            set
            {
                _modelStore = value;
                SelectedModelChanged?.Invoke();
            }
        }

        public event Action SelectedModelChanged;
        public SelectedModelStores(ModelsStore modelsStore)
        {
            _modelsStore = modelsStore;
            _modelsStore.ModelUpdate += _modelsStore_ModelUpdate;
            _modelsStore.ModelDelete += _modelsStore_ModelDelete;
        }

        private void _modelsStore_ModelDelete(Guid modelId)
        {
           if (modelId == ModelStore.ModelId)
            {
                ModelStore = null; 
            }
        }

        private void _modelsStore_ModelUpdate(ModelsModel modelModel)
        {
            if (modelModel.ModelId == ModelStore.ModelId)
            {
                ModelStore = modelModel;
            }
        }
    }
}
