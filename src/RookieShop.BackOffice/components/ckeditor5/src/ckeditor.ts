/**
 * @license Copyright (c) 2014-2024, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */

import { Alignment } from "@ckeditor/ckeditor5-alignment"
import { Autoformat } from "@ckeditor/ckeditor5-autoformat"
import { Bold, Italic } from "@ckeditor/ckeditor5-basic-styles"
import type { EditorConfig } from "@ckeditor/ckeditor5-core"
import { ClassicEditor } from "@ckeditor/ckeditor5-editor-classic"
import { Essentials } from "@ckeditor/ckeditor5-essentials"
import { FindAndReplace } from "@ckeditor/ckeditor5-find-and-replace"
import { FontColor, FontFamily, FontSize } from "@ckeditor/ckeditor5-font"
import { Heading } from "@ckeditor/ckeditor5-heading"
import { Paragraph } from "@ckeditor/ckeditor5-paragraph"
import { TextTransformation } from "@ckeditor/ckeditor5-typing"
import { Undo } from "@ckeditor/ckeditor5-undo"

class Editor extends ClassicEditor {
  public static override builtinPlugins = [
    Alignment,
    Autoformat,
    Bold,
    Essentials,
    FindAndReplace,
    FontColor,
    FontFamily,
    FontSize,
    Heading,
    Italic,
    Paragraph,
    TextTransformation,
    Undo,
  ]

  public static override defaultConfig: EditorConfig = {
    toolbar: {
      items: [
        "heading",
        "|",
        "bold",
        "italic",
        "alignment",
        "|",
        "fontColor",
        "fontFamily",
        "fontSize",
        "|",
        "undo",
        "redo",
        "findAndReplace",
      ],
    },
    language: "en",
  }
}

export default Editor
