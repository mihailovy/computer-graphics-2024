var point_top  = 500;
var point_left = 500;

function placePoint(){
	document.getElementById("point").style.top = point_top  + "px";
	document.getElementById("point").style.left = point_left + "px";
}

function movePoint( step ){
	point_top  -= step;  // point_top  = point_top - 25;
	point_left -= step; // point_top  = point_top * 1.1;
	placePoint();
}

// beshirova@abv.bg - Милена Беширова, 7 у-ще, Смолян 
// да се изпратя
