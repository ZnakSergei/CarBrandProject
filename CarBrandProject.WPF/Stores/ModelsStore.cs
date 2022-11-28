using CarBrandProject.WPF.Commands;
using CarBrandProject.WPF.Models;
using CarBrandProject.WPF.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBrandProject.WPF.Stores
{
    public class ModelsStore
    {
        private readonly IGetAllModelsQuary _getAllModelsQuary;
        private readonly ICreateModelCommand _createModelCommand;
        private readonly IUpdateModelCommand _updateModelCommand;
        private readonly IDeleteModelCommand _deleteModelCommand;
        private readonly List<ModelsModel> _modelsModels;

        public IEnumerable<ModelsModel> modelsModels => _modelsModels;

        public ModelsStore(IGetAllModelsQuary getAllModelsQuary, 
            ICreateModelCommand createModelCommand, 
            IUpdateModelCommand updateModelCommand, 
            IDeleteModelCommand deleteModelCommand)
        {
            _getAllModelsQuary = getAllModelsQuary;
            _createModelCommand = createModelCommand;
            _updateModelCommand = updateModelCommand;
            _deleteModelCommand = deleteModelCommand;

            _modelsModels = new List<ModelsModel>();
        }

        

        public event Action ModelsLoaded;
        public event Action<ModelsModel> ModelAdded;
        public event Action<ModelsModel> ModelUpdate;
        public event Action<Guid> ModelDelete;
        public async Task Add(ModelsModel modelsModel)
        {
            await _createModelCommand.Execute(modelsModel);

            _modelsModels.Add(modelsModel);

            ModelAdded?.Invoke(modelsModel);
        }
        public async Task Update(ModelsModel modelsModel)
        {
            await _updateModelCommand.Execute(modelsModel);

            int currentIndex = _modelsModels.FindIndex(m => m.ModelId == modelsModel.ModelId);
            if (currentIndex == -1)
            {
                _modelsModels[currentIndex] = modelsModel;
            }
            else
            {
                _modelsModels.Add(modelsModel);
            }

            ModelUpdate?.Invoke(modelsModel);
        }

        public async Task Delete(Guid modelId)
        {
            await _deleteModelCommand.Execute(modelId);

            ModelDelete?.Invoke(modelId);

            _modelsModels.RemoveAll(m => m.ModelId == modelId);
        }

        public async Task Load()
        {
            IEnumerable<ModelsModel> models = await _getAllModelsQuary.Execute();

            _modelsModels.Clear();
            _modelsModels.AddRange(models);

            ModelsLoaded?.Invoke();
        }
    }
}
