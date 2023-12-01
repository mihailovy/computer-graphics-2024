var tl1 = {}; 

// Attributes
tl1.status = false;
tl1.col    = 'green';

// Methods
tl1.On = function(){
	this.status = true;
	this.show();
}

tl1.Off = function(){
	this.status = false;
	this.show();
}

tl1.show = function(){
	document.getElementById('tl_red').style.backgroundColor    = "#FFFFFF";
	document.getElementById('tl_yellow').style.backgroundColor = "#FFFFFF";
	document.getElementById('tl_green').style.backgroundColor  = "#FFFFFF";
	if(this.status == true){
		if(     this.col == 'red'){
			document.getElementById('tl_red').style.backgroundColor = "#FF0000";
		}
		else if(this.col == 'yellow'){
			document.getElementById('tl_yellow').style.backgroundColor = "yellow";
		}
		else if(this.col == 'green'){
			document.getElementById('tl_green').style.backgroundColor = "#00FF00";
		}
	}
}

tl1.makeChange = function() {
	if(this.col == 'red'){
		this.col = 'yellow';
	}
	else if(this.col == 'yellow'){
		this.col = 'green';
	}
	else if(this.col == 'green'){
		this.col = 'red';
	}
	else{
		this.col = 'red';
	}
	this.show();
}

tl1.anime = function anime(){
	var timer = setInterval( function(){	tl1.makeChange() }, 1000 );
}
