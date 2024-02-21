const API_URL = 'https://calcount.develotion.com'
const API_IMAGENES = 'https://calcount.develotion.com/imgs'
let alimentos = []
let registros = [];
Inicializar()

function Inicializar() {
  OcultarSecciones()
  AgregarEventos()
}

function OcultarSecciones() {
  let pantallas = document.querySelectorAll('.ion-page')
  for (let i = 1; i < pantallas.length; i++) {
    pantallas[i].style.display = 'none'
  }
}

function AgregarEventos() {
  document
    .getElementById('ruteo')
    .addEventListener('ionRouteWillChange', Navegar)
  document.getElementById('btnRegistro').addEventListener('click', Registro)
  document.getElementById('btnLogin').addEventListener('click', Login)
  document
    .getElementById('btnAgregarAlimento')
    .addEventListener('click', AgregarAlimento)
  document.getElementById('btnFiltrarRegistros').addEventListener('click', ListadoPorFechas)  
}

function Navegar(event) {
  console.log(event)
  OcultarSecciones()
  switch (event.detail.to) {
    case '/':
      document.getElementById('inicio').style.display = 'block'
      break
    case '/Registro':
      document.getElementById('registro').style.display = 'block'
      break
    case '/Login':
      document.getElementById('mensajesLogin').innerHTML = ''
      document.getElementById('login').style.display = 'block'
      break
    case '/CerrarSesion':
      CerrarSesion()
      ruteo.push('/')
      break
    case '/AgregarAlimento':
      ObtenerAlimentos()
      setTimeout(() => {
        LlenarSelectDeAlimentos()
      }, 2000)
      document.getElementById('agregarAlimento').style.display = 'block'
      break
    case '/ListadoRegistros':
      ObtenerAlimentos()
      document.getElementById('listadoRegistros').style.display = 'block'
      ListadoRegistros() 
      break
  }
}

function CerrarMenu() {
  document.getElementById('menu').close()
}

function Registro() {
  let usuario = document.getElementById('usuario').value
  let password = document.getElementById('password').value
  let idPais = document.getElementById('pais').value
  let calorias = document.getElementById('calorias').value
  document.getElementById('mensajesRegistro').innerHTML = ''

  try {
    if (usuario.trim().length === 0) {
      throw new Error('El usuario es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    if (idPais === '') {
      throw new Error('El id de pais es requerido')
    }
    if (calorias === '') {
      throw new Error('La cantidad de calorias son requeridas')
    }
    fetch(`${API_URL}/usuarios.php`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        usuario,
        password,
        idPais,
        caloriasDiarias: calorias,
      }),
    })
      .then(response => response.json())
      .then(data => {
        console.log(data)
        if (data.codigo === 200) {
          localStorage.setItem('apiKey', data.apiKey)
          localStorage.setItem('idUsuario', data.id)
          ruteo.push('/')
        } else {
          document.getElementById('mensajesRegistro').innerHTML = data.mensaje
        }
      })
      .catch(error => console.log(error))
  } catch (error) {
    document.getElementById('mensajesRegistro').innerHTML = error.message
  }
}

function Login() {
  let usuario = document.getElementById('usuarioLogin').value
  let password = document.getElementById('passwordLogin').value

  try {
    if (usuario.trim().length === 0) {
      throw new Error('El usuario es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/login.php`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        usuario,
        password,
      }),
    })
      .then(response =>
        response.ok
          ? response.json()
          : Promise.reject({
              status: response.status,
              mensaje: 'Usuario y/o contraseña incorrectos',
            })
      )
      .then(data => {
        document.getElementById('usuarioLogin').value = ''
        document.getElementById('passwordLogin').value = ''
        document.getElementById('mensajesLogin').innerHTML = `Login exitoso`
        localStorage.setItem('apiKey', data.apiKey)
        localStorage.setItem('idUsuario', data.id)
      })
      .catch(
        error =>
          (document.getElementById('mensajesLogin').innerHTML = error.mensaje)
      )
  } catch (error) {
    document.getElementById('mensajesLogin').innerHTML = error.message
  }
}

function LlenarSelectDeAlimentos() {
  alimentos.forEach(alimento => {
    document.getElementById('alimento').innerHTML += `
      <ion-select-option value="${alimento.id}">${alimento.nombre}</ion-select-option>
      `
  })
}

function ObtenerAlimentos() {
  let idUsuario = localStorage.getItem('idUsuario')
  let apiKey = localStorage.getItem('apiKey')
  fetch(`${API_URL}/alimentos.php`, {
    headers: {
      'Content-Type': 'application/json',
      apikey: apiKey,
      iduser: idUsuario,
    },
  })
    .then(response => response.json())
    .then(data => {
      alimentos = data.alimentos
    })
    .catch(error => console.log(error))
}

function AgregarAlimento() {
  if (localStorage.getItem('apiKey') === null) {
    document.getElementById('mensajesAgregarAlimento').innerHTML =
      'Debe iniciar sesión para agregar un alimento'
  } else {
    let alimento = document.getElementById('alimento').value
    let cantidad = document.getElementById('cantidadAlimento').value
    let fechaInicial = document.getElementById('fechaAlimento').value
    let idUsuario = localStorage.getItem('idUsuario')
    let apiKey = localStorage.getItem('apiKey')
    try {
      if (alimento.trim().length === 0) {
        throw new Error('El alimento es requerido')
      }
      if (cantidad.trim().length === 0) {
        throw new Error('La cantidad de alimento es requerida')
      }
      if (fechaInicial.trim().length === 0) {
        throw new Error('La fecha es requerida')
      }

      let fecha = fechaInicial.split('T')[0]
      if (fecha > new Date().toISOString().split('T')[0]) {
        throw new Error('La fecha no puede ser mayor a la actual')
      }
      fetch(`${API_URL}/registros.php`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          apikey: apiKey,
          iduser: idUsuario,
        },
        body: JSON.stringify({
          idAlimento: alimento,
          idUsuario,
          cantidad,
          fecha,
        }),
      })
        .then(response => response.json())
        .then(data => {
          document.getElementById('mensajesAgregarAlimento').innerHTML =
            data.mensaje
          document.getElementById('alimento').value = ''
          document.getElementById('cantidadAlimento').value = ''
        })
        .catch(error => console.log(error))
    } catch (error) {
      document.getElementById('mensajesAgregarAlimento').innerHTML =
        error.message
    }
  }
}

function CerrarSesion() {
  localStorage.clear()
}


function ListadoRegistros() {
  if (localStorage.getItem('apiKey') === null) {
    document.getElementById('mensajeListadoRegistros').innerHTML =
      'Debe iniciar sesión para ver el listado de registros'
  } else {
    let idUsuario = localStorage.getItem('idUsuario')
    let apiKey = localStorage.getItem('apiKey')
    fetch(`${API_URL}/registros.php?idUsuario=${idUsuario}`, {
      headers: {
        'Content-Type': 'application/json',
        apikey: apiKey,
        iduser: idUsuario,
      },
    })
      .then(response => response.json())
      .then(data => {
        if (data.codigo === 200) {
          document.getElementById('contenidoListadoRegistros').innerHTML = ''
          registros = data.registros //array
          registros.forEach(registro => {
            let alimento = alimentos.find(
              alimento => alimento.id === registro.idAlimento
            )
            document.getElementById('contenidoListadoRegistros').innerHTML += `
              <ion-card style="margin-bottom: 40px;">
                <img alt="${alimento.nombre}" src="${API_IMAGENES}/${alimento.imagen}.png" style="max-width: 100%;height: 200px;"/>
                <ion-card-header>
                  <ion-card-title>${alimento.nombre}</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                  <p>Calorias: ${alimento.calorias}</p>
                  <ion-button onclick='EliminarRegistro(${registro.id})'>Eliminar</ion-button>
                </ion-card-content>
              </ion-card>
            `
          })
        } else {
          document.getElementById('mensajeListadoRegistros').innerHTML =
            data.mensaje
        }
      })
      .catch(error => console.log(error))
  }
}

function ListadoPorFechas(){
  let ionDatetimeElement = document.getElementById('fechaDeFiltro');
  let fechasSeleccionadas = [] = ionDatetimeElement.value;
  let fechaInicio = fechasSeleccionadas[0];
  let fechaFinal = fechasSeleccionadas[1];
  document.getElementById('contenidoListadoRegistros').innerHTML = '';
  registros.forEach(registro => {
    if(registro.fecha>=fechaInicio&&registro.fecha<=fechaFinal){
    let alimento = alimentos.find(
      alimento => alimento.id === registro.idAlimento
    )
    document.getElementById('contenidoListadoRegistros').innerHTML += `
      <ion-card style="margin-bottom: 40px;">
        <img alt="${alimento.nombre}" src="${API_IMAGENES}/${alimento.imagen}.png" style="max-width: 100%;height: 200px;"/>
        <ion-card-header>
          <ion-card-title>${alimento.nombre}</ion-card-title>
        </ion-card-header>
        <ion-card-content>
          <p>Calorias: ${alimento.calorias}</p>
          <ion-button onclick='EliminarRegistro(${registro.id})'>Eliminar</ion-button>
        </ion-card-content>
      </ion-card>
    `}
  })
}

function EliminarRegistro(id) {
  fetch(`${API_URL}/registros.php?idRegistro=${id}`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      apikey: localStorage.getItem('apiKey'),
      iduser: localStorage.getItem('idUsuario'),
    },
  })
    .then(() => ListadoRegistros())
    .catch(error => console.log(error))
    registros.filter(registro => registro.id === id);
}
