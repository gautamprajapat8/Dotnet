import React from "react";
import CodeEditor from "./CodeMirror";
export const Home=()=>{
    return(
        <>
            <div className="home-container">
                <div className="left-panel">
                    <CodeEditor/>
                </div>
                <div className="right-panel">

                </div>
            </div>
        </>
    )
}