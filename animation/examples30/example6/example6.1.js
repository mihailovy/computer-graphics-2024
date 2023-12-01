var clock = {} // Create a new object that is empty

// Object attributes

clock.now      = new Date();
clock.interval = false;

// Object methods
clock.show = function(){
	var theTime = "";
	theTime = theTime +        this.now.getHours();
	theTime = theTime + ":" +  this.now.getMinutes();
	theTime = theTime + ":" +  this.now.getSeconds();
	document.getElementById('clock_time').innerHTML = theTime;
	//
	var theDate = "";
	theDate = theDate       +  this.now.getDate();
	theDate = theDate + "." +  (this.now.getMonth() + 1);
	theDate = theDate + "." +  this.now.getFullYear();
	
	document.getElementById('clock_date').innerHTML = theDate;
}

clock.start = function(){
	clearInterval( this.interval );
	this.interval = setInterval( function(){ clock.change(); }, 100);
}

clock.stop = function(){
	clearInterval( this.interval );
	this.interval == false;
}

clock.change = function(){
	this.now = new Date();
	this.show();
	this.bell();
}

clock.bell = function(){
	var h  = document.getElementById('alm_h').value - 0;
	var m  = document.getElementById('alm_m').value - 0;
	var nh = this.now.getHours();
	var nm = this.now.getMinutes();
	if( nh > h && nm > m){
		document.getElementById('alm_audio').play();
	}
}




























