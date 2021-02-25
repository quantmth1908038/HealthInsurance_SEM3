function Validator(options) {


  const selectorRules = {};

  function validate(inputElement, rule) {
 
    const errorElement = inputElement
      .closest(options.formGroupSelector)
      .querySelector(options.errorSelector);
    let errorMessage;

    //lặp qua từng rule và kiểm translate
    //nếu có lỗi thì dừng việc kiểm tra
    const rulesSelector = selectorRules[rule.selector];
    for (const rules of rulesSelector) {
      switch (inputElement.type) {
        case "radio":
        case "checkbox":
          errorMessage = rules(
            formElement.querySelector(rule.selector + ":checked")
          );
          break;
        default:
          errorMessage = rules(inputElement.value);
      }

      if (errorMessage) break;
    }

    if (errorMessage) {
      errorElement.innerText = errorMessage;
      inputElement.closest(options.formGroupSelector).classList.add("invalid");
    } else {
      errorElement.innerText = "";
      inputElement
        .closest(options.formGroupSelector)
        .classList.remove("invalid");
    }

    return !errorMessage;
  }

  const formElement = document.querySelector(options.form);
  if (formElement) {
    //bỏ đi hành động submit form
    formElement.onsubmit = (e) => {
      e.preventDefault();

      let isFormValid = true;

      //lặp qua từng rules và validate
      options.rules.forEach((rule) => {
        const inputElement = formElement.querySelector(rule.selector);
        const isValid = validate(inputElement, rule);
        if (!isValid) {
          isFormValid = false;
        }
      });
      //trường hợp submit với javascript
      if (isFormValid) {
        if (typeof options.onSubmit === "function") {
          const enableInput = formElement.querySelectorAll(
            "[name]:not([disable])"
          );
          const formValues = Array.from(enableInput).reduce((values, input) => {
            switch (input.type) {
              case "radio":
                values[input.name] = formElement.querySelector(
                  `input[name=${input.name}]:checked`
                ).value;
                break;
              case "checkbox":
                if (!input.matches(":checked")) return values;
                if (!Array.isArray(values[input.name])) {
                  values[input.name] = [];
                }
                values[input.name].push(input.value);
                break;
              case "file":
                values[input.name] = input.files;
                break;
              default:
                values[input.name] = input.value;
            }
            return values;
          }, {});
          options.onSubmit(formValues);
        }
        //trường hợp submit với hành vi mặc định
        else {
          //submit với hành vi mặc định của trình duyệt
          formElement.submit();
        }
      }
    };
    //lặp qua mỗi rule và xử lý (lắng nge sự kiên blur, input,..)
    options.rules.forEach((rule) => {
      //lưu lại các rules cho mỗi input
      if (Array.isArray(selectorRules[rule.selector])) {
        selectorRules[rule.selector].push(rule.test);
      } else {
        selectorRules[rule.selector] = [rule.test];
      }

      const inputElements = formElement.querySelectorAll(rule.selector);
      Array.from(inputElements).forEach((inputElement) => {
        //xử lý trường hợp blur ra ngoài
        inputElement.onblur = function () {
          validate(inputElement, rule);
        };

        //sử lý khi người dùng nhập
        inputElement.oninput = function () {
          const errorElement = inputElement
            .closest(options.formGroupSelector)
            .querySelector(options.errorSelector);
          errorElement.innerText = "";
          inputElement
            .closest(options.formGroupSelector)
            .classList.remove("invalid");
        };
        inputElement.onchange = function () {
          validate(inputElement, rule);
        };
      });
    });
  }
}

Validator.isRequired = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
        return value ? undefined : message || "Please enter this field ";
    },
  };
};

Validator.isEmail = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      const regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        return regex.test(value) ? undefined : message || "Please enter your email ";
    },
  };
};

Validator.minLength = function (selector, min) {
  return {
    selector: selector,
    test: function (value) {
      return value.length >= min
        ? undefined
        : `Vui lòng tối thiểu ${min} ký tự`;
    },
  };
};

Validator.isConfirmed = function (selector, getConfirmValue, message) {
  return {
    selector: selector,
    test: function (value) {
      return value === getConfirmValue()
        ? undefined
        : message || "Giá trị nhập vào không chính xác";
    },
  };
};
