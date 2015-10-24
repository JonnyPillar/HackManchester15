(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({"./Scripts/Application/Application.jsx":[function(require,module,exports){
var temp = require ('./Home');

temp();

},{"./Home":"c:\\Users\\Jonny\\Documents\\GitHub\\HackManchester15\\HackManchesterServer\\Hack.Server\\Scripts\\Application\\Home.jsx"}],"c:\\Users\\Jonny\\Documents\\GitHub\\HackManchester15\\HackManchesterServer\\Hack.Server\\Scripts\\Application\\Home.jsx":[function(require,module,exports){
var CheckLink = React.createClass({displayName: "CheckLink",
    render: function() {
        // This takes any props passed to CheckLink and copies them to <a>

        var temp = [1, 2, 3];

        return(
            React.createElement("div", null, 
                "Hello again", 
                
                    temp.map(function(item){
                        return(
                            React.createElement("b", null, item)
                        );
                    })
                
            )
        );
    }
});

module.exports = function(){
    return (ReactDOM.render(
        CheckLink, document.getElementById('homePanel')
    ));
};

},{}]},{},["./Scripts/Application/Application.jsx"])
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5vZGVfbW9kdWxlcy9icm93c2VyaWZ5L25vZGVfbW9kdWxlcy9icm93c2VyLXBhY2svX3ByZWx1ZGUuanMiLCJjOlxcVXNlcnNcXEpvbm55XFxEb2N1bWVudHNcXEdpdEh1YlxcSGFja01hbmNoZXN0ZXIxNVxcSGFja01hbmNoZXN0ZXJTZXJ2ZXJcXEhhY2suU2VydmVyXFxTY3JpcHRzXFxBcHBsaWNhdGlvblxcQXBwbGljYXRpb24uanN4IiwiYzpcXFVzZXJzXFxKb25ueVxcRG9jdW1lbnRzXFxHaXRIdWJcXEhhY2tNYW5jaGVzdGVyMTVcXEhhY2tNYW5jaGVzdGVyU2VydmVyXFxIYWNrLlNlcnZlclxcU2NyaXB0c1xcQXBwbGljYXRpb25cXEhvbWUuanN4Il0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0FDQUEsQ0FBQyxJQUFJLElBQUksR0FBRyxPQUFPLEVBQUUsUUFBUSxDQUFDLENBQUM7O0FBRS9CLElBQUksRUFBRTs7O0FDRk4sSUFBSSwrQkFBK0IseUJBQUE7QUFDbkMsSUFBSSxNQUFNLEVBQUUsV0FBVztBQUN2Qjs7QUFFQSxRQUFRLElBQUksSUFBSSxHQUFHLENBQUMsQ0FBQyxFQUFFLENBQUMsRUFBRSxDQUFDLENBQUMsQ0FBQzs7UUFFckI7WUFDSSxvQkFBQSxLQUFJLEVBQUEsSUFBQyxFQUFBO0FBQUEsZ0JBQUEsYUFBQSxFQUFBO0FBQUEsZ0JBRUE7b0JBQ0csSUFBSSxDQUFDLEdBQUcsQ0FBQyxTQUFTLElBQUksQ0FBQzt3QkFDbkI7NEJBQ0ksb0JBQUEsR0FBRSxFQUFBLElBQUMsRUFBQyxJQUFTLENBQUE7MEJBQ2Y7cUJBQ0w7Z0JBQ0o7WUFDQyxDQUFBO1VBQ1I7S0FDTDtBQUNMLENBQUMsQ0FBQyxDQUFDOztBQUVILE1BQU0sQ0FBQyxPQUFPLEdBQUcsVUFBVTtJQUN2QixRQUFRLFFBQVEsQ0FBQyxNQUFNO1FBQ25CLFNBQVMsRUFBRSxRQUFRLENBQUMsY0FBYyxDQUFDLFdBQVcsQ0FBQztLQUNsRCxFQUFFO0NBQ04iLCJmaWxlIjoiZ2VuZXJhdGVkLmpzIiwic291cmNlUm9vdCI6IiIsInNvdXJjZXNDb250ZW50IjpbIihmdW5jdGlvbiBlKHQsbixyKXtmdW5jdGlvbiBzKG8sdSl7aWYoIW5bb10pe2lmKCF0W29dKXt2YXIgYT10eXBlb2YgcmVxdWlyZT09XCJmdW5jdGlvblwiJiZyZXF1aXJlO2lmKCF1JiZhKXJldHVybiBhKG8sITApO2lmKGkpcmV0dXJuIGkobywhMCk7dmFyIGY9bmV3IEVycm9yKFwiQ2Fubm90IGZpbmQgbW9kdWxlICdcIitvK1wiJ1wiKTt0aHJvdyBmLmNvZGU9XCJNT0RVTEVfTk9UX0ZPVU5EXCIsZn12YXIgbD1uW29dPXtleHBvcnRzOnt9fTt0W29dWzBdLmNhbGwobC5leHBvcnRzLGZ1bmN0aW9uKGUpe3ZhciBuPXRbb11bMV1bZV07cmV0dXJuIHMobj9uOmUpfSxsLGwuZXhwb3J0cyxlLHQsbixyKX1yZXR1cm4gbltvXS5leHBvcnRzfXZhciBpPXR5cGVvZiByZXF1aXJlPT1cImZ1bmN0aW9uXCImJnJlcXVpcmU7Zm9yKHZhciBvPTA7bzxyLmxlbmd0aDtvKyspcyhyW29dKTtyZXR1cm4gc30pIiwi77u/dmFyIHRlbXAgPSByZXF1aXJlICgnLi9Ib21lJyk7XHJcblxyXG50ZW1wKCk7IiwidmFyIENoZWNrTGluayA9IFJlYWN0LmNyZWF0ZUNsYXNzKHtcclxuICAgIHJlbmRlcjogZnVuY3Rpb24oKSB7XHJcbiAgICAgICAgLy8gVGhpcyB0YWtlcyBhbnkgcHJvcHMgcGFzc2VkIHRvIENoZWNrTGluayBhbmQgY29waWVzIHRoZW0gdG8gPGE+XHJcblxyXG4gICAgICAgIHZhciB0ZW1wID0gWzEsIDIsIDNdO1xyXG5cclxuICAgICAgICByZXR1cm4oXHJcbiAgICAgICAgICAgIDxkaXY+XHJcbiAgICAgICAgICAgICAgICBIZWxsbyBhZ2FpblxyXG4gICAgICAgICAgICAgICAge1xyXG4gICAgICAgICAgICAgICAgICAgIHRlbXAubWFwKGZ1bmN0aW9uKGl0ZW0pe1xyXG4gICAgICAgICAgICAgICAgICAgICAgICByZXR1cm4oXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICA8Yj57aXRlbX08L2I+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICk7XHJcbiAgICAgICAgICAgICAgICAgICAgfSlcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgKTtcclxuICAgIH1cclxufSk7XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IGZ1bmN0aW9uKCl7XHJcbiAgICByZXR1cm4gKFJlYWN0RE9NLnJlbmRlcihcclxuICAgICAgICBDaGVja0xpbmssIGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdob21lUGFuZWwnKVxyXG4gICAgKSk7XHJcbn07Il19
