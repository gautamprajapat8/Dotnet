import React, { useEffect, useRef, useState } from "react";
import { useCodeMirror } from "@uiw/react-codemirror";

import { javascript } from "@codemirror/lang-javascript";

const code = "console.log('hello world!');\n\n\nlet d = 10; \n\n";

const CodeEditor = () => {
    const editor = useRef();
    const { setContainer, ...codeMirrorProps } = useCodeMirror({
        extensions: [javascript()],
       // Set the CodeMirror theme
        basicSetup: {
          lineNumbers: true,
        },
        value: code,
      });
  useEffect(() => {
    if (editor.current) {
      setContainer(editor.current);
      
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [editor.current]);

  const [editorValue, setEditorValue] = useState(code);
  const handleEditorChange = () => {
    // setEditorValue(editor);
    console.log(codeMirrorProps.value);
  };

  

  return (
    <div ref={editor}>
    <button onClick={handleEditorChange}>Get Editor Value</button>
    </div>
  );
};

export default CodeEditor
