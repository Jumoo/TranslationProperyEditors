
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace Jumoo.TranslationManager.NoneTranslatableText
{
    [DataEditor("NonTranslatable.Textbox",
        EditorType.PropertyValue | EditorType.MacroParameter,
        "Non-Translatable Textbox",
        "textbox",
        ValueType = ValueTypes.Text,
        Group = "Common",
        Icon = "icon-application-window-alt color-grey")]
    public class NonTranslatableTextBoxPropertyEditor : DataEditor
    {
        public NonTranslatableTextBoxPropertyEditor(ILogger logger)
            : base(logger)
        { }

        protected override IDataValueEditor CreateValueEditor()
            => new TextOnlyValueEditor(Attribute);

        protected override IConfigurationEditor CreateConfigurationEditor()
            => new TextboxConfigurationEditor();
    }

}
