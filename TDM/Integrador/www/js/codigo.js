const API_URL = 'https://ort-tallermoviles.herokuapp.com/api'
const SRC_IMAGES = 'https://ort-tallermoviles.herokuapp.com/assets/imgs'
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
  document.getElementById('btnLogin').addEventListener('click', Login)
  document.getElementById('btnRegistro').addEventListener('click', Registro)
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
      document.getElementById('login').style.display = 'block'
      break
    case '/ListadoProductos':
      ListadoProductos()
      break
  }
}

function CerrarMenu() {
  document.getElementById('menu').close()
}

function Registro() {
  let nombre = document.getElementById('nombre').value
  let apellido = document.getElementById('apellido').value
  let email = document.getElementById('email').value
  let direccion = document.getElementById('direccion').value
  let password = document.getElementById('password').value
  document.getElementById('mensajesRegistro').innerHTML = ''

  try {
    if (nombre.trim().length === 0) {
      throw new Error('El nombre es requerido')
    }
    if (apellido.trim().length === 0) {
      throw new Error('El apellido es requerido')
    }
    if (email.trim().length === 0) {
      throw new Error('El email es requerido')
    }
    if (direccion.trim().length === 0) {
      throw new Error('La direccion es requerida')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/usuarios`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        nombre,
        apellido,
        email,
        direccion,
        password,
      }),
    })
      .then(response => response.json())
      .then(data => {
        console.log(data)
        if (!data.error) {
          document.getElementById('nombre').value = ''
          document.getElementById('apellido').value = ''
          document.getElementById('email').value = ''
          document.getElementById('direccion').value = ''
          document.getElementById('password').value = ''
          document.getElementById('mensajesRegistro').innerHTML =
            'Registro exitoso, ya puedes iniciar sesion'
        } else {
          document.getElementById('mensajesRegistro').innerHTML = data.error
        }
      })
      .catch(error => console.log(error))
  } catch (error) {
    document.getElementById('mensajesRegistro').innerHTML = error
  }
}

function Login() {
  let email = document.getElementById('emailLogin').value
  let password = document.getElementById('passwordLogin').value
  document.getElementById('mensajesLogin').innerHTML = ''

  try {
    if (email.trim().length === 0) {
      throw new Error('El email es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/usuarios/session`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email,
        password,
      }),
    })
      .then(response =>
        response.ok
          ? response.json()
          : Promise.reject({
              status: response.status,
              mensaje: 'Usuario o contraseña incorrectos',
            })
      )
      .then(data => {
        document.getElementById('mensajesLogin').innerHTML = `Login exitoso`
        localStorage.setItem('token', data.data.token)
      })
      .catch(
        error =>
          (document.getElementById('mensajesLogin').innerHTML = error.mensaje)
      )
  } catch (error) {
    document.getElementById('mensajesLogin').innerHTML = error.message
  }
}

function ListadoProductos() {
  OcultarSecciones()
  let token = localStorage.getItem('token')
  document.getElementById('listadoProductos').style.display = 'block'
  document.getElementById('mensajesListadoProductos').innerHTML = ''
  if (localStorage.getItem('token') !== null) {
    fetch(`${API_URL}/productos`, {
      headers: {
        'Content-Type': 'application/json',
        'x-auth': token,
      },
    })
      .then(response =>
        response.ok
          ? response.json()
          : Promise.reject({
              status: response.status,
              mensaje:
                'No estas autorizado para ver esta seccion, debes loguearte',
            })
      )
      .then(data => {
        const productos = data.data
        for (let i = 0; i < productos.length; i++) {
          document.getElementById('contenidoListadoProductos').innerHTML += `
          <ion-button fill="clear" onclick='DetalleProducto(${JSON.stringify(
            productos[i]
          )})'>
            <ion-card style="margin-bottom: 40px;">
            <img alt="${productos[i].nombre}" src="${SRC_IMAGES}/${
            productos[i].urlImagen
          }.jpg" style="max-width: 100%;height: 200px;"/>
              <ion-card-header>
                <ion-card-title>${productos[i].nombre}</ion-card-title>
              </ion-card-header>
              <ion-card-content>
                <p>Precio: $${productos[i].precio}</p>
                <p>Codigo: ${productos[i].codigo}</p>
                <p>Etiquetas: ${productos[i].etiquetas}</p>
                <p>Estado: ${productos[i].estado}</p>
              </ion-card-content>
            </ion-card>
          </ion-button>
          `
        }
      })
      .catch(error => {
        if (error.status === 401) {
          document.getElementById('mensajesListadoProductos').innerHTML =
            error.mensaje
        }
      })
  } else {
    document.getElementById('mensajesListadoProductos').innerHTML =
      'No estas autorizado para ver esta seccion, debes loguearte'
  }
}

function DetalleProducto(producto) {
  OcultarSecciones()
  document.getElementById('detalleProducto').style.display = 'block'
  document.getElementById('mensajesDetalleProducto').innerHTML = ''
  document.getElementById('contenidoDetalleProducto').innerHTML = `
    <ion-card style="margin-bottom: 40px;">
      <img alt="imagen de fondo" src="${SRC_IMAGES}/${producto.urlImagen}.jpg" style="max-width: 100%;height: 200px;"/>
      <ion-card-header>
        <ion-card-title>${producto.nombre}</ion-card-title>
      </ion-card-header>
      <ion-card-content>
        <p>Precio: $${producto.precio}</p>
        <p>Codigo: ${producto.codigo}</p>
        <p>Etiquetas: ${producto.etiquetas}</p>
        <p>Estado: ${producto.estado}</p>
        <ion-button onclick='ListadoProductos()'>Volver</ion-button>
      </ion-card-content>
    </ion-card>
  `
}
