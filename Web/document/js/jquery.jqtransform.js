(function(e){var t={preloadImg:true};var n=false;var r=function(e){e=e.replace(/^url\((.*)\)/,"$1").replace(/^\"(.*)\"$/,"$1");var t=new Image;t.src=e.replace(/\.([a-zA-Z]*)$/,"-hover.$1");var n=new Image;n.src=e.replace(/\.([a-zA-Z]*)$/,"-focus.$1")};var i=function(t){var n=e(t.get(0).form);var r=t.next();if(!r.is("label")){r=t.prev();if(r.is("label")){var i=t.attr("id");if(i){r=n.find('label[for="'+i+'"]')}}}if(r.is("label")){return r.css("cursor","pointer")}return false};var s=function(t){var n=e(".jqTransformSelectWrapper ul:visible");n.each(function(){var n=e(this).parents(".jqTransformSelectWrapper:first").find("select").get(0);if(!(t&&n.oLabel&&n.oLabel.get(0)==t.get(0))){e(this).hide()}})};var o=function(t){if(e(t.target).parents(".jqTransformSelectWrapper").length===0){s(e(t.target))}};var u=function(){e(document).mousedown(o)};var a=function(t){var n;e(".jqTransformSelectWrapper select",t).each(function(){n=this.selectedIndex<0?0:this.selectedIndex;e("ul",e(this).parent()).each(function(){e("a:eq("+n+")",this).click()})});e("a.jqTransformCheckbox, a.jqTransformRadio",t).removeClass("jqTransformChecked");e("input:checkbox, input:radio",t).each(function(){if(this.checked){e("a",e(this).parent()).addClass("jqTransformChecked")}})};e.fn.jqTransInputButton=function(){return this.each(function(){var n=$(this).attr("datasize").split(","),r=n[0],i=n[1];t=e('<button style="width:'+r+"px;height:"+i+'px" id="'+this.id+'" name="'+this.name+'" type="'+this.type+'" class="'+this.className+' jqTransformButton"><span>'+e(this).attr("value")+"</span>").hover(function(){t.addClass("jqTransformButton_hover")},function(){t.removeClass("jqTransformButton_hover")}).mousedown(function(){t.addClass("jqTransformButton_click")}).mouseup(function(){t.removeClass("jqTransformButton_click")});e(this).replaceWith(t)})};e.fn.jqTransInputText=function(){return this.each(function(){var t=e(this);if(t.hasClass("jqtranformdone")||!t.is("input")){return}t.addClass("jqtranformdone");var n=i(e(this));n&&n.bind("click",function(){t.focus()});var r=t.width();if(t.attr("datasize")){r=t.attr("datasize");t.css("width",r-10)}t.addClass("jqTransformInput").wrap('<div class="jqTransformInputWrapper"><div class="jqTransformInputInner"><div></div></div></div>');var s=t.parent().parent().parent();s.css("width",r);t.focus(function(){s.addClass("jqTransformInputWrapper_focus")}).blur(function(){s.removeClass("jqTransformInputWrapper_focus")}).hover(function(){s.addClass("jqTransformInputWrapper_hover")},function(){s.removeClass("jqTransformInputWrapper_hover")});this.wrapper=s})};e.fn.jqTransCheckBox=function(){return this.each(function(){if(e(this).hasClass("jqTransformHidden")){return}var t=e(this);var n=this;var r=i(t);r&&r.click(function(){s.trigger("click")});var s=e('<a href="#" class="jqTransformCheckbox"></a>');t.addClass("jqTransformHidden").wrap('<span class="jqTransformCheckboxWrapper"></span>').parent().prepend(s);t.change(function(){this.checked&&s.addClass("jqTransformChecked")||s.removeClass("jqTransformChecked");return true});s.click(function(){if(t.attr("disabled")){return false}t.trigger("click").trigger("change");return false});this.checked&&s.addClass("jqTransformChecked")})};e.fn.jqTransRadio=function(){return this.each(function(){if(e(this).hasClass("jqTransformHidden")){return}var t=e(this);var n=this;oLabel=i(t);oLabel&&oLabel.click(function(){r.trigger("click")});var r=e('<a href="#" class="jqTransformRadio" rel="'+this.name+'"></a>');t.addClass("jqTransformHidden").wrap('<span class="jqTransformRadioWrapper"></span>').parent().prepend(r);t.change(function(){n.checked&&r.addClass("jqTransformChecked")||r.removeClass("jqTransformChecked");return true});r.click(function(){if(t.attr("disabled")){return false}t.trigger("click").trigger("change");e('input[name="'+t.attr("name")+'"]',n.form).not(t).each(function(){e(this).attr("type")=="radio"&&e(this).trigger("change")});return false});n.checked&&r.addClass("jqTransformChecked")})};e.fn.jqTransTextarea=function(){return this.each(function(){var t=e(this);if(t.hasClass("jqtransformdone")){return}t.addClass("jqtransformdone");oLabel=i(t);oLabel&&oLabel.click(function(){t.focus()});var n=t.width();if(t.attr("datasize")){var n=t.attr("datasize").split(","),r=n[0]-10,s=n[1]}t.wrap('<div class="jqTransformTextarea"><div></div></div>');var o=t;o.css({width:r,height:s});t.focus(function(){o.addClass("jqTransformTextarea_focus")}).blur(function(){o.removeClass("jqTransformTextarea_focus")}).hover(function(){o.addClass("jqTransformTextarea_hover")},function(){o.removeClass("jqTransformTextarea_hover")});this.wrapper=o})};e.fn.jqTransSelect=function(){return this.each(function(t){var n=e(this);if(n.hasClass("jqTransformHidden")){return}if(n.attr("multiple")){return}var r=i(n),o=n.addClass("jqTransformHidden").wrap('<div class="jqTransformSelectWrapper"></div>').parent().css({zIndex:10-t});o.prepend('<div><span></span><a href="#" class="jqTransformSelectOpen"></a></div><ul></ul>');var u=e("ul",o).css("width",n.width()).hide();e("option",this).each(function(t){var n=e('<li><a href="#" index="'+t+'">'+e(this).html()+"</a></li>");u.append(n)});u.on("click","a",function(){e("a.selected",o).removeClass("selected");e(this).addClass("selected");if(n[0].selectedIndex!=e(this).attr("index")&&n[0].onchange){n[0].selectedIndex=e(this).attr("index");n[0].onchange()}n[0].selectedIndex=e(this).attr("index");e("span:eq(0)",o).html(e(this).html());u.hide();return false});e("a:eq("+this.selectedIndex+")",u).click();e("span:first",o).on("click",function(){e("a.jqTransformSelectOpen",o).trigger("click")});r&&r.on("click",function(){e("a.jqTransformSelectOpen",o).trigger("click")});this.oLabel=r;var a=e("a.jqTransformSelectOpen",o).on("click",function(){if(u.css("display")=="none"){s()}if(n.attr("disabled")){return false}u.slideToggle("fast",function(){var t=e("a.selected",u).offset().top-u.offset().top;u.animate({scrollTop:t})});return false});var f=n.outerWidth();var l=e("span:first",o);var c=f>l.innerWidth()?f+a.outerWidth():o.width();var h=n.attr("datasize").split(",");newWidth=h[0];newMarginLeft=h[1];newMarginRight=h[2];o.css({width:newWidth+"px","margin-left":newMarginLeft+"px","margin-right":newMarginRight+"px"});u.css("width",newWidth);l.css({width:f});u.css({display:"block",visibility:"hidden"});var p="auto";p<u.height()&&u.css({height:p,overflow:"hidden"});u.css({display:"none",visibility:"visible"})})};e.fn.jqTransInputFile=function(){var t=e(this);if(t.hasClass("jqtranformdone")||!t.is('span[class="jqFileInput"]')){return}e(".jqFileInput").bind("click",function(e){var t=$(this).attr("data-rel");$(".fileUpload-"+t).trigger("click").change(function(){fileName=$(this).val().split(/[\/\\]+/);fileName=fileName[fileName.length-1];$(this).parent().find(".fileUpload-"+t).text(fileName).end().find(".fileUpload-"+t).val(fileName)});return false})};e.fn.jqTransform=function(n){var r=e.extend({},t,n);return this.each(function(){var t=e(this);if(t.hasClass("jqtransformdone")){return}t.addClass("jqtransformdone");e('input:reset, input[type="button"]',this).jqTransInputButton();e("input:text, input:password",this).jqTransInputText();e("input:checkbox",this).jqTransCheckBox();e("input:radio",this).jqTransRadio();e("textarea",this).jqTransTextarea();e('span[class="jqFileInput"]',this).jqTransInputFile();if(e("select",this).jqTransSelect().length>0){u()}t.bind("reset",function(){var e=function(){a(this)};window.setTimeout(e,10)})})}})(jQuery)