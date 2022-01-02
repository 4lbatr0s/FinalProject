let add = function(x){
    return function(y){
      return x + y;
    };
  }
  
  var addTwo = add(2);
  
  console.log(addTwo(4) === 6); // true
  console.log(add(3)(4) === 7); // true