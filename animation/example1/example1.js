function add()
{
  let a = document.getElementById('a').value;
  let b = document.getElementById('b').value;
  
  a = parseFloat(a);
  b = parseFloat(b);
  let c = a-(-b);
  
  document.getElementById('r').value = c;
  return false;
}

