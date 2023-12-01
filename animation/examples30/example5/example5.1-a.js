var tl1 = { 
  // Attributes
  'status': false,
  'col'   : 'green',
  
  // Methods
  'On': function() {
    this.status = true;
    this.show();
  }, 
  'Off': function(){
    this.status = false;
    this.show();
  },
  'show': function() {
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
  },
  'makeChange': function() {
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
  },
  'anime': function anime(){
    var timer = setInterval( function(){	tl1.makeChange() }, 1000 );
  }
};
