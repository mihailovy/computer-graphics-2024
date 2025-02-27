function placeItem(itemId, x, y, w)
{
	let item = document.getElementById(itemId);
    item.style.left  = x - w/2 + "px";
    item.style.top   = y - w/2 + "px";
    item.style.width = w + "px";
}

function circleAnimate(x1, y1, w, R){
	var alphaEarth = 0; // Earth rotation angle
	var alphaMoon  = 0; // Moon rotation angle
	var xEarth = R*Math.cos(alphaEarth) + x1; // Earth x coordinate
	var yEarth = R*Math.sin(alphaEarth) + y1; // Earth y coordinate
	var interv = setInterval(makemove, 10);   // Timer
	var earthW = w;    // Width of Earth's picture
	var moonR  = R/3;  // Moonr rotation radius
	
	function makemove() {
		// Calculate the current Earth coordinates
		xEarth = R*Math.cos(alphaEarth) + x1;
		yEarth = R*Math.sin(alphaEarth) + y1;
		if(alphaEarth > 2 * Math.PI) {
			alphaEarth = 0;
		} 
		else {
			alphaEarth = alphaEarth + Math.PI /900;
		}
		placeItem('earth', xEarth, yEarth, earthW);
		
        // Calculate Moon's xm, ym
	    let xMoon = moonR*Math.cos(alphaMoon) + xEarth; // Moon x coordinate
	    let yMoon = moonR*Math.sin(alphaMoon) + yEarth; // Moon y coordinate
	    if(alphaMoon > 2 * Math.PI) {
			alphaMoon2 = 0;
		} 
		else {
			alphaMoon = alphaMoon - Math.PI /900;
		}
	    let moonW   = w/2;
		placeItem('moon', xMoon, yMoon, moonW);
	} 
}

// PLace the sun at the center of the browser window
let sunX = window.innerWidth  / 2; // Sun x coordinate
let sunY = window.innerHeight / 2; // Sun y coordinate
let sunW = 200;		               // Width of sun's image
let earthW = 100;                  // Width of earth's image
let earthR = 250;                  // Earth rotation radius

onload = (event) => {
	placeItem('sun'  , sunX         , sunY , sunW);
	// placeItem('earth', sunX + earthR, sunY , earthW); 
	// placeItem('moon' , sunX + earthR, sunY , earthW/2);
	circleAnimate( sunX, sunY, earthW, earthR)
};
