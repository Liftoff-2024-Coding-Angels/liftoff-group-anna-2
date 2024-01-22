import React from "react"
import './Share.css'

interface Shareprops{
    description: string
}

function Share({description}: Shareprops) {
    //const url = window.location.href;


return(
    <>
    Share us on:
    <div  className="share-icon-collections">
    
    <a href={`https://www.facebook.com/sharer/sharer.php?u= https://github.com/Liftoff-2024-Coding-Angels/liftoff-group-anna-2/tree/main`} target="_blank">
    <svg className="share-icon" xmlns="http://www.w3.org/2000/svg" style={{width:30}} viewBox="0 0 512 512" aria-label="fb" role="img"><path d="m375.14,288l14.22,-92.66l-88.91,0l0,-60.13c0,-25.35 12.42,-50.06 52.24,-50.06l40.42,0l0,-78.89s-36.68,-6.26 -71.75,-6.26c-73.22,0 -121.08,44.38 -121.08,124.72l0,70.62l-81.39,0l0,92.66l81.39,0l0,224l100.17,0l0,-224l74.69,0z"></path></svg> 
    </a>

      <a href={`https://twitter.com/intent/tweet?url=https://github.com/Liftoff-2024-Coding-Angels/liftoff-group-anna-2/tree/main&text=${encodeURI(description)}`} target="_blank">
    <svg className="share-icon" xmlns="http://www.w3.org/2000/svg" style={{width:30}} viewBox="0 0 512 512" aria-label="tw" role="img"><path d="M459.37 151.716c.325 4.548.325 9.097.325 13.645 0 138.72-105.583 298.558-298.558 298.558-59.452 0-114.68-17.219-161.137-47.106 8.447.974 16.568 1.299 25.34 1.299 49.055 0 94.213-16.568 130.274-44.832-46.132-.975-84.792-31.188-98.112-72.772 6.498.974 12.995 1.624 19.818 1.624 9.421 0 18.843-1.3 27.614-3.573-48.081-9.747-84.143-51.98-84.143-102.985v-1.299c13.969 7.797 30.214 12.67 47.431 13.319-28.264-18.843-46.781-51.005-46.781-87.391 0-19.492 5.197-37.36 14.294-52.954 51.655 63.675 129.3 105.258 216.365 109.807-1.624-7.797-2.599-15.918-2.599-24.04 0-57.828 46.782-104.934 104.934-104.934 30.213 0 57.502 12.67 76.67 33.137 23.715-4.548 46.456-13.32 66.599-25.34-7.798 24.366-24.366 44.833-46.132 57.827 21.117-2.273 41.584-8.122 60.426-16.243-14.292 20.791-32.161 39.308-52.628 54.253z"></path></svg>
    </a>
    

</div>

</>
)
}

export default Share

