/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	config.language = 'en';
	config.toolbar = 'Mine';
	config.disableObjectResizing = true;
	config.disableNativeSpellChecker = true;
	config.autoUpdateElement = true;

	config.toolbar_Basic =
	[
		['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'About']
	];

	config.toolbar_Mine =
	[
		['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Scayt'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
		['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
		['TextColor','BGColor', 'Image'],
		'/',
        ['Bold', 'Italic', 'Strike'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
        ['Link', 'Unlink', 'Anchor'],
        ['Maximize', '-', 'Preview', 'Source'],
		['Styles', 'Format', 'FontSize']
	];
};