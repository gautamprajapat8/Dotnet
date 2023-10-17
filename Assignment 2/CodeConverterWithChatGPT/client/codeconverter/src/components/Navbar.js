import React from "react";
export const Navbar=()=>{
    return(
        <>
            <div className="navbar">
                <div>
                    <select className="navbar-bbutton">
                        <option>Python</option>
                        <option>Javascript</option>
                        <option>Java</option>
                    </select>
                </div>
                <div>
                    <button className="navbar-bbutton">
                        Convert
                    </button>
                </div>
                <div>
                    <button className="navbar-bbutton">
                        Debug
                    </button>
                </div>
                <div>
                        <button className="navbar-bbutton">Quality Check</button>
                </div>
            </div>
        </>
    )
}