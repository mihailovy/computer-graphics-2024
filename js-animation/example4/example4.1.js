var brx_max = 1500;
var bry_max = 500;

function getMax(a, b){
	if( a > b){
		// Ако лявата променлива е по-голяма от дясната, връщаме нейната стойност
		return( a );
	}
	else{
		// Иначе връщаме стойността на дясната променлива
		return( b );
	}
}

function getBrx( x ){
	// Тук използваме за взимане на мащаб горната функция getScale() 
	var brx = x;
	brx = Math.round(brx);
	return(brx);
}

function getBry( y ){
	var bry = bry_max - y;
	bry = Math.round(bry);
	return(bry);
}

function moveItemTo(itemId, x, y){
	var brx = getBrx( x );
	var bry = getBry( y );
	document.getElementById(itemId).style.left = brx + "px";
	document.getElementById(itemId).style.top  = bry + "px";
	//console.log("Move " + itemId + " to x =" + x + ", y = " + y);
}

function placeItem( filename, itemId, x, y ){
	document.getElementById(itemId).style.background = "transparent url('" + filename + "') no-repeat center center";
	moveItemTo(itemId, x, y)
}

function linearAnimate(itemId, x1, y1, x2, y2){
	var k = (y1 - y2) / (x1 - x2);
	var n = y1 - k * x1;
	var x = x1;
	var y = k * x + n;
	var interv = setInterval(makemove, 10);
	
	function makemove() {
		y = k * x + n;
		if(x >= x2) {
			clearInterval(interv);
		} 
		else {
			x = x + 10;
		}
		moveItemTo(itemId, x, y);
	} 
}

function paraboleAnimate(itemId, x1, y1, x2, y2){
	var xm = (x1 + x2) / 2 ;
	var ym = (2*Math.random()+ 1) * getMax(y1, y2);
	
	// Коефиценти
	var k  = (y1 - ym)/((x1 - xm)*(x1 - x2)) - (y2 - ym)/((x2 - xm)*(x1 - x2));
	var p  = (y1 - ym)/(x1 - xm)             - k*(x1 + xm);
	var n  = y1 - p*x1 - k * x1 * x1;
	
	var x  = x1;
	var y  = k*x*x + p*x + n;
	var interv = setInterval(makemove, 10);
	
	function makemove() {
		y = k*x*x + p*x + n;
		if(x >= x2) {
			clearInterval(interv);
		} 
		else {
			x = x + 3;
		}
		moveItemTo(itemId, x, y);
	} 
}

function circleAnimate(itemId, x1, y1, R){
  
	var alpha = 0;
	var x = R*Math.cos(alpha) + x1;
	var y = R*Math.sin(alpha) + y1;
	var interv = setInterval(makemove, 10);
	
	function makemove() {
    x = R*Math.cos(alpha) + x1;
	  y = R*Math.sin(alpha) + y1;
		if(alpha >= 200 * 3.14151) {
			clearInterval(interv);
		} 
		else {
			alpha = alpha + 3.1415/900;
		}
		moveItemTo(itemId, x, y);
	} 
}

