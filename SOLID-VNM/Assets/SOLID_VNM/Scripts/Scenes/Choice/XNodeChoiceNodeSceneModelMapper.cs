using System.Linq;

using UnityEngine;

namespace SOLID_VNM.Scenes.Choice
{
    public interface XNodeChoiceNodeSceneModelMapper : XNodeSceneModelSceneModelMapper<XNodeChoiceModel, ChoiceSceneModel>
    {
    }

    public class XNodeChoiceNodeSceneModelMapperImpl : XNodeChoiceNodeSceneModelMapper
    {
        private readonly ChoiceSceneModelImpl.Factory _choiceSceneModelFactory;
        private readonly ChoiceModelImpl.Factory _choiceModelFactory;


        public XNodeChoiceNodeSceneModelMapperImpl(ChoiceSceneModelImpl.Factory choiceSceneModelFactory, ChoiceModelImpl.Factory choiceModelFactory)
        {
            _choiceSceneModelFactory = choiceSceneModelFactory;
            _choiceModelFactory = choiceModelFactory;
        }

        ChoiceSceneModel XNodeSceneModelSceneModelMapper<XNodeChoiceModel, ChoiceSceneModel>.From(XNodeChoiceModel model)
        {
            Sprite background = model.background;
            ChoiceModelImpl[] choices = CreateChoices(model);

            return _choiceSceneModelFactory.Create(background, choices);
        }

        private ChoiceModelImpl[] CreateChoices(XNodeChoiceModel model)
        {
            string[] choices = model.choices;

            return choices.Select(choiceText => _choiceModelFactory.Create(choiceText)).ToArray();
        }
    }
}
