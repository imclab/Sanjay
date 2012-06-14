    
    //Load Google Earth within the browser
    
    var ge;
    var counter = 0;
    var lineStringPlacemark;    
    google.load("earth", "1");
    google.load("maps", "2");
    
    //Initialization function
    function init() {         
      google.earth.createInstance('map3d', initCallback, failureCallback);
	  map = new GMap2(document.getElementById('map'));
	  map.setCenter(new GLatLng(0, 0), 0);	  
      GUI();
    }    
    
    //Function called if successfully loaded gEarth.
    function initCallback(instance) {
      ge = instance;
      ge.getWindow().setVisibility(true);
    
      // add a navigation control
      ge.getNavigationControl().setVisibility(ge.VISIBILITY_AUTO);	  
	  ge.getOptions().setOverviewMapVisibility(true);
      // add some layers
      ge.getLayerRoot().enableLayerById(ge.LAYER_BORDERS, true);
      ge.getLayerRoot().enableLayerById(ge.LAYER_ROADS, true);
      ge.getLayerRoot().enableLayerById(ge.LAYER_BUILDINGS, true);
      ge.getLayerRoot().enableLayerById(ge.LAYER_TERRAIN, true);
      
      google.earth.addEventListener(ge.getView(), 'viewchange', function(evt) {
            map.clearOverlays();

            var totalBounds = new GLatLngBounds();

            // get the globe bounds (method 1)
            var globeBounds = ge.getView().getViewportGlobeBounds();
            var fakeBoundsCenter = null;

            if (globeBounds) {
              globeBounds.setNorth(Math.min(globeBounds.getNorth(), 85));
              globeBounds.setSouth(Math.max(globeBounds.getSouth(), -85));

              if (globeBounds.getEast() == 180 && globeBounds.getWest() == -180) {
                fakeBoundsCenter = new GLatLng(0, 0);
                var globeBoundsPolygon = new GPolygon([
                    new GLatLng(globeBounds.getNorth(), -179),
                    new GLatLng(globeBounds.getNorth(), 0),
                    new GLatLng(globeBounds.getNorth(), 179),
                    new GLatLng(globeBounds.getSouth(), 179),
                    new GLatLng(globeBounds.getSouth(), 0),
                    new GLatLng(globeBounds.getSouth(), -179),
                    new GLatLng(globeBounds.getNorth(), -179)],
                    '#0000ff', 2, 1.00,
                    '#0000ff',    0.25,
                    { clickable: false });
              } else {
                var globeBoundsPolygon = new GPolygon([
                    new GLatLng(globeBounds.getNorth(), globeBounds.getWest()),
                    new GLatLng(globeBounds.getNorth(), globeBounds.getEast()),
                    new GLatLng(globeBounds.getSouth(), globeBounds.getEast()),
                    new GLatLng(globeBounds.getSouth(), globeBounds.getWest()),
                    new GLatLng(globeBounds.getNorth(), globeBounds.getWest())],
                    '#0000ff', 2, 1.00,
                    '#0000ff',    0.25,
                    { clickable: false });
              }

              map.addOverlay(globeBoundsPolygon);

              var polyBounds = globeBoundsPolygon.getBounds();
              totalBounds.extend(polyBounds.getNorthEast());
              totalBounds.extend(polyBounds.getSouthWest());
            }

            // hit test the corners (method 2)
            var hitTestTL = ge.getView().hitTest(0, ge.UNITS_FRACTION, 0, ge.UNITS_FRACTION, ge.HIT_TEST_GLOBE);
            var hitTestTR = ge.getView().hitTest(1, ge.UNITS_FRACTION, 0, ge.UNITS_FRACTION, ge.HIT_TEST_GLOBE);
            var hitTestBR = ge.getView().hitTest(1, ge.UNITS_FRACTION, 1, ge.UNITS_FRACTION, ge.HIT_TEST_GLOBE);
            var hitTestBL = ge.getView().hitTest(0, ge.UNITS_FRACTION, 1, ge.UNITS_FRACTION, ge.HIT_TEST_GLOBE);

            // ensure that all hit tests succeeded (i.e. the viewport is 2d-mappable)
            if (hitTestTL && hitTestTR && hitTestBL && hitTestBR) {
              var hitTestBoundsPolygon = new GPolygon([
                  new GLatLng(hitTestTL.getLatitude(), hitTestTL.getLongitude()),
                  new GLatLng(hitTestTR.getLatitude(), hitTestTR.getLongitude()),
                  new GLatLng(hitTestBR.getLatitude(), hitTestBR.getLongitude()),
                  new GLatLng(hitTestBL.getLatitude(), hitTestBL.getLongitude()),
                  new GLatLng(hitTestTL.getLatitude(), hitTestTL.getLongitude())],
                  '#ff0000', 2, 1.00,
                  '#ff0000',    0.25,
                  { clickable: false });
              map.addOverlay(hitTestBoundsPolygon);

              var polyBounds = hitTestBoundsPolygon.getBounds();
              totalBounds.extend(polyBounds.getNorthEast());
              totalBounds.extend(polyBounds.getSouthWest());
            }

            if (!totalBounds.isEmpty()) {
              map.setCenter(fakeBoundsCenter ? fakeBoundsCenter : totalBounds.getCenter(),
                  map.getBoundsZoomLevel(totalBounds));
            }
          });
      
      Planes();     
      
      document.getElementById('installed-plugin-version').innerHTML =
        ge.getPluginVersion().toString();      
        }
    
    //Function called if fail to load google earth.
    function failureCallback(errorCode) {    
    }   
    
    function Planes(){           
      var val = parseInt(document.getElementById("total").value);
      for(var i=0;i<val;i++){
      //parseFloat(document.getElementById("total"));i++){
      var placemark = ge.createPlacemark('');
      placemark.setName(document.getElementById("flightno"+ i.toString()).value);
      ge.getFeatures().appendChild(placemark);

      // Create style map for placemark
      var icon = ge.createIcon('');
      icon.setHref('http://aegamez.com/airplane.png');
      var style = ge.createStyle('');
      style.getIconStyle().setIcon(icon);
      placemark.setStyleSelector(style);

      // Create point      
      var point = ge.createPoint('');
      point.setLatitude(parseFloat(document.getElementById("lat"+ i.toString()).value));
      point.setLongitude(parseFloat(document.getElementById("lon"+ i.toString()).value));
      point.setAltitudeMode(ge.ALTITUDE_RELATIVE_TO_GROUND);
      point.setAltitude(parseFloat(document.getElementById("alt"+ i.toString()).value)/50);
      placemark.setGeometry(point);
      placemark.setDescription('Source  - ' + document.getElementById("source"+ i.toString()).value 
      + '<br>Destination - ' + document.getElementById("dest"+ i.toString()).value
      + '<br>Altitude - ' + document.getElementById("alt"+ i.toString()).value 
      + 'fts<br>Departure - ' + document.getElementById("dep"+ i.toString()).value 
      + '<br>Airline - ' + document.getElementById("airline"+ i.toString()).value);
      
      AddPath(parseFloat(document.getElementById("lat"+ i.toString()).value),
      parseFloat(document.getElementById("lon"+ i.toString()).value),
      parseFloat(document.getElementById("alt"+ i.toString()).value)/50);
      }
    }
    function AddPath(lat,lon,alt){
      lineStringPlacemark = ge.createPlacemark('');
      var lineString = ge.createLineString('');
      lineStringPlacemark.setGeometry(lineString);
      lineString.setTessellate(true);
      lineString.setExtrude(true);
      lineString.setAltitudeMode(ge.ALTITUDE_RELATIVE_TO_GROUND);

      // add the the points to the line string geometry
      addToLineString(lineString, lat, lon,   0,   0, alt);
      addToLineString(lineString, lat, lon, 0.5,  0.5, alt);
      ge.getFeatures().appendChild(lineStringPlacemark);
      lineStringPlacemark.setStyleSelector(ge.createStyle(''));
      var lineStyle = lineStringPlacemark.getStyleSelector().getLineStyle();      
      var polyStyle = lineStringPlacemark.getStyleSelector().getPolyStyle();
      
      polyStyle.setFill(true);
      polyStyle.getColor().set('ffffffff');
      polyStyle.setOutline(false);
      lineStyle.setWidth(5);
      lineStyle.getColor().set('99992599');  // aabbggrr format
    }
    
    function addToLineString(lineString, lat, lng, latOffset, lngOffset,altitude) {
        lineString.getCoordinates().pushLatLngAlt(lat + latOffset, lng + lngOffset, altitude);
    }        
    function GUI(){
      addSampleUIHtml(
        '<input id="location" type="text" value="Ahmedabad,India"/>'
      );    
      addSampleButton('Go', buttonClick);      
    }   
    
    function addSampleUIHtml(html) {
        document.getElementById('sample-ui').innerHTML += html;
      }
    
    function addSampleButton(caption, clickHandler) {
        var btn = document.createElement('input');
        btn.type = 'button';
        btn.value = caption;
        
        if (btn.attachEvent)
          btn.attachEvent('onclick', clickHandler);
        else
          btn.addEventListener('click', clickHandler, false);

        // add the button to the Sample UI
        document.getElementById('sample-ui').appendChild(btn);
      }    
    
    //Searching and Navigating to a location.
    function buttonClick() {
      var geocodeLocation = document.getElementById('location').value;
    
      var geocoder = new google.maps.ClientGeocoder();
      geocoder.getLatLng(geocodeLocation, function(point) {
        if (point) {
          var lookAt = ge.createLookAt('');
          lookAt.set(point.y, point.x, 10, ge.ALTITUDE_RELATIVE_TO_GROUND,
                     0, 60, 20000);
          ge.getView().setAbstractView(lookAt);
        }
      });
    }