"use client"

import { ChangeEventHandler } from "react"
import { CKEditor } from "@ckeditor/ckeditor5-react"

import Editor from "../ckeditor5/build/ckeditor"

export default function CustomEditor(
  props: Readonly<{
    event: ChangeEventHandler<HTMLTextAreaElement> | undefined
    content: string
    handleContent: (content: string) => void
  }>
) {
  return (
    <CKEditor
      editor={Editor}
      data={props?.content}
      config={Editor.defaultConfig}
      onChange={(event, editor) => {
        const newData = editor.getData()
        props.handleContent(newData)
        event
      }}
      
    />
  )
}
