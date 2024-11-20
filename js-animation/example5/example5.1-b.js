
var status = false;
var col    = 'green';

// Methods
function On()
{
	status = true;
	show();
}

function Off()
{
	status = false;
	show();
}

function show()
{
	document.getElementById('tl_red').style.backgroundColor    = "#FFFFFF";
	document.getElementById('tl_yellow').style.backgroundColor = "#FFFFFF";
	document.getElementById('tl_green').style.backgroundColor  = "#FFFFFF";
	if(status == true){
		if(     col == 'red'){
			document.getElementById('tl_red').style.backgroundColor = "#FF0000";
		}
		else if(col == 'yellow'){
			document.getElementById('tl_yellow').style.backgroundColor = "yellow";
		}
		else if(col == 'green'){
			document.getElementById('tl_green').style.backgroundColor = "#00FF00";
		}
	}
}

function makeChange()
{
	if(col == 'red'){
		col = 'yellow';
	}
	else if(col == 'yellow'){
		col = 'green';
	}
	else if(col == 'green'){
		col = 'red';
	}
	else{
		col = 'red';
	}
	show();
}

function anime()
{
	var timer = setInterval( function(){	makeChange() }, 1000 );
}
