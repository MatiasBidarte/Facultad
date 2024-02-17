const ruteo = document.querySelector("#ruteo");
Inicializar();
function Inicializar() {
  OcultarPantallas();
  AgregarEventos();
}

function OcultarPantallas() {
  let pantallas = document.querySelectorAll(".ion-page");
  for (let i = 1; i < pantallas.length; i++) {
    pantallas[i].style.display = "none";
  }
}
function AgregarEventos() {
  ruteo.addEventListener("ionRouteWillChange", Navegar);
}
function CerrarMenu(){
    document.querySelector("#menu").close();
}
function Navegar(evt) {
  console.log(evt);
  OcultarPantallas();
  switch (evt.detail.to) {
    case "/":
      document.querySelector("#inicio").style.display = "block";
      break;
    default:
      document.querySelector("#login").style.display = "block";
      break;
  }
}
