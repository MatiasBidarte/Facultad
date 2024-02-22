const baseURL = 'https://ort-tallermoviles.herokuapp.com/api'
const baseURLImage = 'https://ort-tallermoviles.herokuapp.com/assets/imgs/'
const ruteo = document.querySelector('#ruteo')
let latitudOrigen = -34.877749
let longitudOrigen = -56.170776
let marcadores
let map

navigator.geolocation.getCurrentPosition(GuardarUbicacion, ErrorUbicacion)
Inicializar()

function Inicializar() {
  OcultarPantallas()
  AgregarEventos()
  if (
    localStorage.getItem('token') != null &&
    localStorage.getItem('token') != ''
  ) {
    ruteo.push('/ListadoProductos')
  } else {
    ruteo.push('/')
  }
}
function GuardarUbicacion(position) {
  latitudOrigen = position.coords.latitude
  longitudOrigen = position.coords.longitude
}
function ErrorUbicacion(Error) {
  MostrarError({ message: 'No se pudo obtener la ubicacion' })
}

function OcultarPantallas() {
  let pantallas = document.querySelectorAll('.ion-page')
  for (let i = 1; i < pantallas.length; i++) {
    pantallas[i].style.display = 'none'
  }
}
function CerrarMenu() {
  document.querySelector('#menu').close()
}
function AgregarEventos() {
  ruteo.addEventListener('ionRouteWillChange', Navegar)
  document.querySelector('#btnLogin').addEventListener('click', Login)
  document.querySelector('#btnRegistro').addEventListener('click', Registro)
  document
    .querySelector('#sucursales')
    .addEventListener('ionChange', MostrarSucursalEnMapa)
}
function Navegar(evt) {
  OcultarPantallas()
  switch (evt.detail.to) {
    case '/':
      document.querySelector('#inicio').style.display = 'block'
      break
    case '/Login':
      document.querySelector('#login').style.display = 'block'
      break
    case '/ListadoProductos':
      ObtenerProductos()
      document.querySelector('#listadoProductos').style.display = 'block'
      break
    case '/CerrarSesion':
      CerrarSesion()
      ruteo.push('/')
    case '/DetalleProducto':
      document.querySelector('#detalleProducto').style.display = 'block'
      break
    case '/RealizarPedido':
      document.querySelector('#realizarPedido').style.display = 'block'
      break
    case '/Mapa':
      if (map != null) {
        map.remove()
      }
      MostrarSucursales()
      setTimeout(() => {
        CargarMapa()
      }, 1000)

      document.querySelector('#mapa').style.display = 'block'

      break
    default:
      document.querySelector('#registro').style.display = 'block'
      break
  }
}
function Login() {
  try {
    let nombreUsuario = document.querySelector('#txtNombreUsuario').value
    let password = document.querySelector('#txtPassword').value

    if (nombreUsuario.trim().length == 0 || password.trim().length == 0) {
      throw new Error('Los datos no son correctos')
    }
    let user = {
      email: nombreUsuario,
      password: password,
    }
    LlamadaAFetch(user)
  } catch (Error) {
    document.querySelector('#mensajeLogin').innerHTML = `${Error.message}`
  }
}
function Registro() {
  try {
    let nombreUsuario = document.querySelector('#txtEmail').value
    let password = document.querySelector('#txtPasswordRegistro').value
    let direccion = document.querySelector('#txtDireccion').value
    let nombre = document.querySelector('#txtNombre').value
    let apellido = document.querySelector('#txtApellido').value
    ValidarDatos(nombre, apellido, direccion, nombreUsuario, password)
    fetch(baseURL + '/usuarios', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        nombre: nombre,
        apellido: apellido,
        direccion: direccion,
        email: nombreUsuario,
        password: password,
      }),
    })
      .then(function (response) {
        if (response.ok) {
          document.querySelector('#mensajeRegistro').innerHTML =
            'Registro exitoso'
          LimpiarCampos()
        } else {
          return response.json()
        }
      })
      .then(function (data) {
        console.log(data)
        if (data.error == '') {
          document.querySelector('#mensajeRegistro').innerHTML =
            'Registro exitoso'
          LimpiarCampos()
        } else {
          document.querySelector('#mensajeRegistro').innerHTML = `${data.error}`
        }
      })
      .catch(function (error) {
        document.querySelector(
          '#mensajeRegistro'
        ).innerHTML = `${error.message}`
      })
  } catch (Error) {
    document.querySelector('#mensajeRegistro').innerHTML = Error.message
  }
}

function ValidarDatos(nombre, apellido, direccion, email, password) {
  if (nombre.trim().length == 0) {
    throw new Error('El nombre es requerido')
  }
  if (apellido.trim().length == 0) {
    throw new Error('El apellido es requerido')
  }
  if (direccion.trim().length == 0) {
    throw new Error('La direccion es obligatoria')
  }
  if (email.trim().length == 0) {
    throw new Error('El email es requerido')
  }

  if (password.trim().length == 0) {
    throw new Error('La password es obligatoria')
  }
  if (password.trim().length < 8) {
    throw new Error('La password debe tener como minimo 8 caracteres')
  }
}
function LimpiarCampos() {
  document.querySelector('#txtEmail').value = ''
  document.querySelector('#txtDireccion').value = ''
  document.querySelector('#txtNombre').value = ''
  document.querySelector('#txtApellido').value = ''
  document.querySelector('#txtPasswordRegistro').value = ''
}
function LlamadaAFetch(user) {
  fetch(baseURL + '/usuarios/session', {
    method: 'POST',
    headers: {
      'Content-type': 'application/json',
    },
    body: JSON.stringify(user),
  })
    .then(function (response) {
      if (response.status == 401) {
        return Promise.reject({
          error: response.status,
          message: 'No autorizado',
        })
      }
      return response.json()
    })
    .then(function (data) {
      if (data.error == '') {
        document.querySelector('#mensajeLogin').innerHTML = 'Login exitoso'
        document.querySelector('#txtNombreUsuario').value = ''
        document.querySelector('#txtPassword').value = ''
        localStorage.setItem('token', data.data.token)
      } else {
        document.querySelector('#mensajeLogin').innerHTML = `${data.error}`
      }
    })
    .catch(function (error) {
      document.querySelector('#mensajeLogin').innerHTML = `${error.message}`
    })
}
function ObtenerProductos() {
  if (
    localStorage.getItem('token') != null &&
    localStorage.getItem('token') != ''
  ) {
    fetch(baseURL + '/productos', {
      headers: {
        'Content-type': 'application/json',
        'x-auth': localStorage.getItem('token'),
      },
    })
      .then(function (response) {
        if (response.status == 401) {
          return Promise.reject({
            codigo: response.status,
            message: 'Debe iniciar sesion para visualizar los productos',
          })
        }
        return response.json()
      })
      .then(function (datos) {
        let datosProductosAPI = datos.data
        let datosProductos = ''
        for (let i = 0; i < datosProductosAPI.length; i++) {
          datosProductos += `<ion-card>
  <img alt="${datosProductosAPI[i].nombre}" 
  src="${baseURLImage}${datosProductosAPI[i].urlImagen}.jpg" />
  <ion-card-header>
    <ion-card-title>${datosProductosAPI[i].nombre}</ion-card-title>   
  </ion-card-header>
  <ion-card-content>
    <p>${datosProductosAPI[i].precio}</p>
    <p>${datosProductosAPI[i].codigo}</p>
    <p>${datosProductosAPI[i].estado}</p>
    <p>${datosProductosAPI[i].etiquetas}</p>
    <ion-button onclick='Detalle("${datosProductosAPI[i]._id}")'>Ver detalle</ion-button>
  </ion-card-content>
</ion-card>`
        }
        document.querySelector('#listado').innerHTML = datosProductos
      })
      .catch(function (Error) {
        document.querySelector('#listado').innerHTML = Error.message
      })
  } else {
    document.querySelector('#listado').innerHTML =
      'Debe iniciar sesion para visualizar el listado de productos'
  }
}
function CerrarSesion() {
  localStorage.clear()
  //localStorage.removeItem("token");
}

function Detalle(codigoProducto) {
  let token = localStorage.getItem('token')
  if (codigoProducto != null && token != null) {
    fetch(
      'https://ort-tallermoviles.herokuapp.com/api/productos/' + codigoProducto,
      {
        headers: {
          'Content-type': 'application/json',
          'x-auth': token,
        },
      }
    )
      .then(function (response) {
        if (response.status == 401) {
          return Promise.reject({
            codigo: response.status,
            message: 'Debe iniciar sesion',
          })
        }
        if (response.ok) {
          return response.json()
        } else {
          return Promise.reject({
            codigo: response.status,
            message: 'Datos incorrectos',
          })
        }
      })
      .then(function (datos) {
        let data = `<p>Descripcion ${datos.data.descripcion}</p><p>Nombre: ${datos.data.nombre}</p>`
        data += `<p>Precio ${datos.data.precio}</p> `
        data += `<p>Estado ${datos.data.estado}</p> `
        data += `<p>Etiquetas ${datos.data.etiquetas}</p> `
        data += `<p>Puntaje ${datos.data.puntaje}</p> `
        if (datos.data.estado == 'en stock') {
          data += `<ion-button onclick=RealizarPedido('${datos.data._id}')>Realizar pedido</ion-button>`
        }
        data += `<ion-button onclick='Volver()'>Volver</ion-button>`

        document.querySelector('#detalle').innerHTML = data
        ruteo.push('/DetalleProducto')
      })
      .catch(MostrarError)
  }
}

function RealizarPedido(idProducto) {
  console.log('Falta implementar esta parte')
  ruteo.push('/RealizarPedido')
}

function Volver() {
  ruteo.back()
}
function MostrarError(error) {
  let toast = document.createElement('ion-toast')
  toast.message = error.message
  toast.duration = 1000
  document.body.appendChild(toast)
  return toast.present()
}
function CargarMapa() {
  /*if(map!=null){
        map.remove();
    }  */
  map = L.map('map').setView([latitudOrigen, longitudOrigen], 13)
  L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution:
      '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
  }).addTo(map)
  L.marker([latitudOrigen, longitudOrigen]).addTo(map)
}
function MostrarSucursales() {
  if (
    localStorage.getItem('token') != null &&
    localStorage.getItem('token') != ''
  ) {
    fetch(baseURL + '/sucursales', {
      headers: {
        'Content-type': 'application/json',
        'x-auth': localStorage.getItem('token'),
      },
    })
      .then(response =>
        response.ok
          ? response.json()
          : response.status == 401
          ? Promise.reject({ message: 'Debes iniciar sesion' })
          : Promise.reject({ message: 'Datos incorrectos' })
      )

      .then(function (datos) {
        let options = ''

        datos.data.forEach(element => {
          let q = element.direccion + ',' + element.ciudad + ',' + element.pais
          console.log(q)
          fetch(
            'https://nominatim.openstreetmap.org/search?q=' + q + '&format=json'
          )
            .then(function (response) {
              if (response.ok) {
                return response.json()
              }
              return Promise.reject({ message: response.status })
            })
            .then(function (data) {
              if (data != null && data[0] != null) {
                let idOption = data[0].lat + ',' + data[0].lon
                options += `<ion-select-option value=${idOption}>${element.nombre}</ion-select-option>`
                // markers.push({ latitude: data[0].latitude, longitude: data[0].longitude });opcional
              }

              console.log(options)

              document.querySelector('#sucursales').innerHTML = options
            })
            .catch(MostrarError)
        })
      })

      .catch(MostrarError)
  }
}
function MostrarSucursalEnMapa() {
  let datos = this.value.split(',')
  L.marker([datos[0], datos[1]]).addTo(map)
}
