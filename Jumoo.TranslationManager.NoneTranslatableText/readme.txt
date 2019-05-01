Translation Manager - Non translatable text property values.
============================================================

this package provides two property editors, Non-Translatable Textbox
and Non-Translatable Textarea

These behave exactly the same as Umbraco's build in textbox and
textarea, except they have a diffrent editor alias, which means 
Translation Manager won't pick them up as text to translate.

This can be useful at any point where you have a deeply nested 
text value that you don't want to send to translation. For example
an api key within a grid or nested content element.
