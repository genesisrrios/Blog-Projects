<template>
  <div id="map"></div>
</template>

<script>
import { bus } from '../main'

export default {
  data () {
    return {
      map: null,
      apiResults:null,
      marker: null
    }
  },
  created (){
    bus.$on('user-input', (userInput) => {
      this.getCountryInformation(userInput);
    })
  },
  mounted() {
    this.prepareMap();
  },
  methods: {
    getCountryInformation: function (userInput) {
      let self = this;
      fetch(`https://restcountries.eu/rest/v2/name/${userInput}`)
      .then(response => response.json())    
      .then(data => self.apiResults = data[0])
    },
    prepareMap: function () {
      /* eslint-disable */ 
      this.map = L.map('map').setView([18.2388, -66.0352], 13);
      let mainlayer = L.tileLayer(
          'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
          {
              maxZoom: 18,
              attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>, &copy; <a href="https://carto.com/attribution">CARTO</a>',
          }
      );
      mainlayer.addTo(this.map);
    },
    markCoordinates: function (coordinates) {
      if(this.marker)
        this.map.removeLayer(this.marker);
      this.marker = L.marker(coordinates).addTo(this.map);
      this.map.flyTo(coordinates, 10);
    },
    mapInformationControl: function () {
      let element = document.getElementById('leaflet-information-box');
      if(element)
        element.parentNode.removeChild(element);
      let self = this;
      let informationBox = L.control({position: 'bottomleft'});
      let div = L.DomUtil.create('div', 'leaflet-bar leaflet-control leaflet-control-custom');
      div.id = 'leaflet-information-box'
      div.style.backgroundColor = 'white';
      div.style.width = '100%';
      div.style.paddingTop = '10px';
      div.style.paddingLeft = '7px';
      div.style.height = '400px';
      div.style.overflow = 'auto';
      div.innerHTML += `<h5>Informacion sobre: ${this.apiResults.name}</h5>`;
      div.innerHTML += '<br>'
      div.innerHTML += `<p>Capital: ${this.apiResults.capital}</p>`
      div.innerHTML += `<p>Sub Region: ${this.apiResults.subregion}</p>`
      div.innerHTML += `<p>Moneda: ${this.apiResults.currencies[0].name} ${this.apiResults.currencies[0].symbol}</p>`
      div.innerHTML += `<img class="fluid" style="height:90px;width:90px;" src="${this.apiResults.flag}" alt="Country flag"></img>`
      informationBox.onAdd = function (map) {
        return div;
      }   
      informationBox.addTo(this.map);
    }
  },
  watch : {
    apiResults () {
      let coordinates = this.apiResults.latlng;
      this.markCoordinates(coordinates);
      this.mapInformationControl();
    }
  }
}
</script>

<style>
#map { 
  height: 600px;
  width: 100% 
}

</style>