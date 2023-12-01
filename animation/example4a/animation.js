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

function circleAnimate(itemId, x1, y1, R){
  
	var alpha = 0;
	var x = R*Math.cos(alpha) + x1;
	var y = R*Math.sin(alpha) + y1;
	var interv = setInterval(makemove, 10);
	
	function makemove() {
    x = 0.9*R*Math.cos(alpha) + x1;
	  y = R*Math.sin(alpha) + y1;
		//if(alpha >= 200 * Math.PI) {
			// clearInterval(interv);
		//} 
	//	else {
			alpha = alpha + Math.PI/1000;
		//}
		moveItemTo(itemId, x, y);
	} 
}

