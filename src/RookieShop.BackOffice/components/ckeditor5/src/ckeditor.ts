/**
 * @license Copyright (c) 2014-2024, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */

import { Alignment } from "@ckeditor/ckeditor5-alignment"
import { Bold, Italic } from "@ckeditor/ckeditor5-basic-styles"
import type { EditorConfig } from "@ckeditor/ckeditor5-core"
import { ClassicEditor } from "@ckeditor/ckeditor5-editor-classic"
import { Essentials } from "@ckeditor/ckeditor5-essentials"
import { FindAndReplace } from "@ckeditor/ckeditor5-find-and-replace"
import { FontColor, FontFamily, FontSize } from "@ckeditor/ckeditor5-font"
import { Heading } from "@ckeditor/ckeditor5-heading"
import { Highlight } from "@ckeditor/ckeditor5-highlight"
import { Indent, IndentBlock } from "@ckeditor/ckeditor5-indent"
import { Link } from "@ckeditor/ckeditor5-link"
import { Paragraph } from "@ckeditor/ckeditor5-paragraph"
import { Undo } from "@ckeditor/ckeditor5-undo"

// You can read more about extending the build with additional plugins in the "Installing plugins" guide.
// See https://ckeditor.com/docs/ckeditor5/latest/installation/plugins/installing-plugins.html for details.

class Editor extends ClassicEditor {
  public static override builtinPlugins = [
    Alignment,
    Bold,
    Essentials,
    FindAndReplace,
    FontColor,
    FontFamily,
    FontSize,
    Heading,
    Highlight,
    Indent,
    IndentBlock,
    Italic,
    Link,
    Paragraph,
    Undo,
  ]

  public static override defaultConfig: EditorConfig = {
    toolbar: {
      items: [
        "heading",
        "|",
        "bold",
        "italic",
        "link",
        "alignment",
        "|",
        "fontColor",
        "fontFamily",
        "fontSize",
        "|",
        "outdent",
        "indent",
        "|",
        "undo",
        "redo",
        "|",
        "findAndReplace",
        "highlight",
      ],
    },
    language: "en",
  }
}

export default Editor
