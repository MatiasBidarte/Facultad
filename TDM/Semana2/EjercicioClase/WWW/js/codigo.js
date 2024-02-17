//ObtenerStatusPaises()

/* function ObtenerStatusPaises() {
  fetch('https://restcountries.com/v3.1/all')
    .then(response => {
      if (response.status === 200) return response.json()
      return Promise.reject({
        codigo: response.status,
        mensaje: 'Datos incorrectos',
      })
    })
    .then(datos => {
      for (let i = 0; i < datos.length; i++) {
        console.log(datos[i].status)
      }
    })
    .catch(error => console.log(error))
} */

const MostrarNombresPaises = () => {
  fetch('https://restcountries.com/v3.1/all')
    .then(response => {
      if (response.ok) return response.json()
      return Promise.reject({
        codigo: response.status,
        mensaje: 'Datos incorrectos',
      })
    })
    .then(paises => {
      let nombrePaises = ''
      for (let i = 0; i < paises.length; i++) {
        nombrePaises += `<p>${paises[i].translations.spa.official}</p>`
      }
      document.body.innerHTML = nombrePaises
    })
    .catch(error => console.log(error))
}

MostrarNombresPaises()
