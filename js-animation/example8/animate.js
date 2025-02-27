function placeItem(itemId, x, y, w)
{
	let item = document.getElementById(itemId);
    item.style.left  = x - w/2 + "px";
    item.style.top   = y - w/2 + "px";
    item.style.width = w + "px";
}

function animateEarth(x, y, w)
{
    let earth = document.getElementById('earth');
    earth.style.left = x - w/2 + "px";
    earth.style.top  = y - w/2 + "px";
}

function circleAnimate(x1, y1, w, R){
  
	var alpha = 0;
	var x = R*Math.cos(alpha) + x1;
	var y = R*Math.sin(alpha) + y1;
	var interv = setInterval(makemove, 10);
	var earthW = w;
	
	function makemove() {
      x = R*Math.cos(alpha) + x1;
	  y = R*Math.sin(alpha) + y1;
		if(alpha >= 200 * Math.PI) {
			clearInterval(interv);
		} 
		else {
			alpha = alpha + Math.PI /900;
		}
		animateEarth(x, y, earthW);
	} 
}
